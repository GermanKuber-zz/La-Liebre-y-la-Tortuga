using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class TrackManagerShould
    {
        private readonly TrackManager _sut;
        private readonly Mock<ITracksFactory> _mockTrackFactory;
        private readonly Mock<IPlayer> _mockFirstPlayer = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _mockSecondPlayer = new Mock<IPlayer>();
        private readonly Mock<IPlaceTrackStrategy> _mockPlaceTrackStrategy = new Mock<IPlaceTrackStrategy>();

        public TrackManagerShould()
        {
            _mockTrackFactory = new Mock<ITracksFactory>();
            _mockPlaceTrackStrategy.Setup(x => x.PlaceTracks(It.IsAny<List<ITrack>>()))
                .Returns(() => new ReadOnlyCollection<ITrack>(new List<ITrack> { new Mock<ITrack>().Object, new Mock<ITrack>().Object }));

            _sut = new TrackManager(_mockTrackFactory.Object);
        }

        [Fact]
        public void Put_All_Track_In_A_List()
        {
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);
            _sut.Track.Should().NotBeNull();
        }

        [Fact]
        public void Notify_User_To_Choose_Side()
        {
            var firstPlayerCall = 0;
            var secondPlayerCall = 0;
            _mockFirstPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>())).Callback(() => ++firstPlayerCall);
            _mockSecondPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>())).Callback(() => ++secondPlayerCall);
            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);

            firstPlayerCall.Should().Be(2);
            secondPlayerCall.Should().Be(2);
        }
        [Theory]
        [InlineData(SideOfTrackEnum.DownSide, SideOfTrackEnum.DownSide, SideOfTrackEnum.DownSide)]
        [InlineData(SideOfTrackEnum.UpSide, SideOfTrackEnum.DownSide, SideOfTrackEnum.UpSide)]
        [InlineData(SideOfTrackEnum.UpSide, SideOfTrackEnum.UpSide, SideOfTrackEnum.UpSide)]
        public void See_The_Result_of_the_Users_In_The_Selection_Of_The_Side(SideOfTrackEnum playerOneSide, SideOfTrackEnum playerTwoSide, SideOfTrackEnum resultSide)
        {
            _mockFirstPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(playerOneSide);

            _mockSecondPlayer.Setup(x => x.ChooseSideOfTrack(It.IsAny<ITrack>()))
                .Returns(playerTwoSide);

            _sut.PlaceTracks(new List<IPlayer> { _mockFirstPlayer.Object, _mockSecondPlayer.Object }, _mockPlaceTrackStrategy.Object);

            _sut.Track.Should().Contain(x => x.SideBoder.SideOfTrack.SideType == resultSide);
        }
    }
}