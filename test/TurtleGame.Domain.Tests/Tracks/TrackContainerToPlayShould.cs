using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class TrackContainerToPlayShould
    {
        private Mock<SideOfTrack> _mockCurrentSide = new Mock<SideOfTrack>();
        private ITrackContainerToPlay _sut;
        private Mock<ITrack> _mockTrack = new Mock<ITrack>();
        public TrackContainerToPlayShould()
        {
            _mockCurrentSide.SetupAllProperties();
            _sut = new TrackContainerToPlay(_mockTrack.Object,
                                            SideOfTrackEnum.UpSide);
        }

        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut.SetNext(null, SideOfTrackEnum.UpSide);

            call.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Create_With_Up_Side()
        {
            var called = false;
            _mockTrack.Setup(x => x.UpSide).Callback(() => called = true);
            _sut.SetNext(_mockTrack.Object, SideOfTrackEnum.UpSide);
            called.Should().Be(true);
        }
        [Fact]
        public void Create_With_Down_Side()
        {
            var called = false;
            _mockTrack.Setup(x => x.DownSide).Callback(() => called = true);
            _sut.SetNext(_mockTrack.Object, SideOfTrackEnum.DownSide);
            called.Should().Be(true);
        }
        [Fact]
        public void Create_Next_Container()
        {
            _sut.SetNext(_mockTrack.Object, SideOfTrackEnum.UpSide);
            _sut.Next.Should().NotBeNull();
        }
    }
}