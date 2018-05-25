using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Chain.DecideSide;
using TurtleGame.Domain.Tracks.Strategies.Interfaces;
using TurtleGame.Domain.Tracks.Types;
using Xunit;

namespace TurtleGame.Domain.Tests.Tracks
{
    public class TrackManagerShould
    {
        private readonly TrackManager _sut;
        private readonly Mock<IDecideSideFactory> _mockDecideSideFactory = new Mock<IDecideSideFactory>();
        private readonly Mock<DecideSideChain> _mockDecideSideChain = new Mock<DecideSideChain>();
        private readonly Mock<IPlayer> _mockFirstPlayer = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _mockSecondPlayer = new Mock<IPlayer>();
        private readonly Mock<IMixTrackStrategy> _mockPlaceTrackStrategy = new Mock<IMixTrackStrategy>();
        private readonly Mock<ISideBoderSelected> _mockSideBoderSelected = new Mock<ISideBoderSelected>();
        private readonly Mock<ISideOfTrack> _mockSideOfTrack = new Mock<ISideOfTrack>();
        public TrackManagerShould()
        {
            var mockTrackFactory = new Mock<ITracksFactory>();
            _mockSideBoderSelected.Setup(x => x.SideOfTrack).Returns(_mockSideOfTrack.Object);
            _mockSideBoderSelected.Setup(x => x.SideOfTrack.SideType).Returns(SideOfTrackEnum.UpSide);
            _mockFirstPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>())).Returns(_mockSideBoderSelected.Object);
            _mockSecondPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>())).Returns(_mockSideBoderSelected.Object);
            _mockPlaceTrackStrategy.Setup(x => x.MixTracks(It.IsAny<List<ITrack>>()))
                .Returns(() => new ReadOnlyCollection<ITrack>(new List<ITrack> { new Mock<ITrack>().Object, new Mock<ITrack>().Object }));

            _mockDecideSideChain.Setup(x => x.Decide(It.IsAny<IReadOnlyCollection<SideOfTrackEnum>>())).Returns(_mockSideOfTrack.Object);
            _mockDecideSideFactory.Setup(x => x.Create()).Returns(_mockDecideSideChain.Object);

            _sut = new TrackManager(mockTrackFactory.Object, _mockDecideSideFactory.Object);
        }

        [Fact]
        public void Put_All_Track_In_A_List()
        {
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);
            _sut.Track.Should().NotBeNull();
        }
        [Fact]
        public void First_Track_Be_Starting_Track()
        {
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);
            _sut.Track.First().SideBoder.Track.Should().BeOfType<StartingLineTrack>();
        }

        [Fact]
        public void Have_Final_Line_By_Last_Track()
        {
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);
            _sut.Track.Last().SideBoder.Track.Should().BeOfType<FinalLineTrack>();
        }
        [Fact]
        public void Notify_User_To_Choose_Side()
        {
            var firstPlayerCall = 0;
            var secondPlayerCall = 0;
            _mockFirstPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(_mockSideBoderSelected.Object)
                .Callback(() => ++firstPlayerCall);

            _mockSecondPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(_mockSideBoderSelected.Object)
                .Callback(() => ++secondPlayerCall);
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);

            firstPlayerCall.Should().Be(2);
            secondPlayerCall.Should().Be(2);
        }
        [Theory]
        [InlineData(SideOfTrackEnum.DownSide, SideOfTrackEnum.DownSide, SideOfTrackEnum.DownSide)]
        [InlineData(SideOfTrackEnum.UpSide, SideOfTrackEnum.DownSide, SideOfTrackEnum.UpSide)]
        [InlineData(SideOfTrackEnum.UpSide, SideOfTrackEnum.UpSide, SideOfTrackEnum.UpSide)]
        public void See_The_Result_of_the_Users_In_The_Selection_Of_The_Side(SideOfTrackEnum playerOneSide, 
            SideOfTrackEnum playerTwoSide, 
            SideOfTrackEnum resultSide)
        {

            var mockFirst = new Mock<ISideBoderSelected>();
            mockFirst.Setup(x => x.SideOfTrack.SideType).Returns(playerOneSide);

            _mockFirstPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(mockFirst.Object);
            var mockSecond = new Mock<ISideBoderSelected>();
            mockSecond.Setup(x => x.SideOfTrack.SideType).Returns(playerTwoSide);
            _mockSecondPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(mockSecond.Object);

            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);

            _sut.Track.Should().Contain(x => x.SideBoder.SideOfTrack.SideType == resultSide);
        }
    }
}