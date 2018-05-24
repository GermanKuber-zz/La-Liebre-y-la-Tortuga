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
        private Func<ITrack, SideOfTrackEnum> _choseSideOfTrack = (track) => SideOfTrackEnum.UpSide;
        public PlayerShould()
        {
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
                return SideOfTrackEnum.DownSide;
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
            _choseSideOfTrack = (x) => sideChoosed;
            _sut = new Player(_choseSideOfTrack);
            _sut.ChooseSideOfTrack(mockTrack.Object).Should().Be(sideChoosed);
        }
    }
}