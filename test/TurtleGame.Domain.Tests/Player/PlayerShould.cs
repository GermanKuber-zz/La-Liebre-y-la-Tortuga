using FluentAssertions;
using Moq;
using System;
using Xunit;
using static TurtleGame.Domain.TrackBase;

namespace TurtleGame.Domain.Tests
{
    public class PlayerShould
    {
        private Player _sut;
        private Mock<ISideBoderSelected> _mockSideBorderSelected = new Mock<ISideBoderSelected>();
        private Func<ITrack, ISideBoderSelected> _choseSideOfTrack;
        public PlayerShould()
        {
            _choseSideOfTrack = (track) => _mockSideBorderSelected.Object;
            _sut = new Player(_choseSideOfTrack);
        }
        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut = new Player(null);

            call.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Notify_When_Receive_Track_To_Chose_Side()
        {
            var mockTrack = new Mock<ITrack>();
            var call = false;
            _choseSideOfTrack = (x) =>
            {
                call = true;
                return _mockSideBorderSelected.Object;
            };
            _sut = new Player(_choseSideOfTrack);
            _sut.ChooseSideOfTrack(mockTrack.Object);
            call.Should().Be(true);
        }

        [Theory]
        [InlineData(SideOfTrackEnum.DownSide)]
        [InlineData(SideOfTrackEnum.UpSide)]
        public void Notify_Return_Same_Value_That_I_Returned(SideOfTrackEnum sideChoosed)
        {
            var mockTrack = new Mock<ITrack>();
            _choseSideOfTrack = (x) => _mockSideBorderSelected.Object;

            _mockSideBorderSelected.Setup(x => x.SideOfTrack.SideType).Returns(sideChoosed);

            _sut = new Player(_choseSideOfTrack);
            _sut.ChooseSideOfTrack(mockTrack.Object).SideOfTrack.SideType.Should().Be(sideChoosed);
        }
        [Fact]
        public void Accept_One_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(1);
        }
        [Fact]
        public void Accept_Two_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(2);
        }
        [Fact]
        public void Produced_Error_Doest_Not_Accept_More_Than_Two_BetCards()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            Action act = () => _sut.GiveCard(new Mock<IBetCard>().Object);

            act.Should().Throw<ArgumentException>();
        }

    }
}