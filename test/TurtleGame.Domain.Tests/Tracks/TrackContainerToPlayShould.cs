using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class TrackContainerToPlayShould
    {
        private Mock<SideOfTrackSelector> _mockCurrentSide = new Mock<SideOfTrackSelector>();
        private ITrackContainerToPlay _sut;
        private Mock<ITrack> _mockTrack = new Mock<ITrack>();
        private Mock<ISideOfTrack> _mockSideOfTrack = new Mock<ISideOfTrack>();
        public TrackContainerToPlayShould()
        {
            _mockCurrentSide.SetupAllProperties();
            _sut = new TrackContainerToPlay(new SideBoderSelect(_mockTrack.Object, _mockSideOfTrack.Object, new Mock<IBorderOfTrack>().Object));
        }

        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut.SetNext(null);

            call.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Create_Next_Container()
        {
            _sut.SetNext(new SideBoderSelect(_mockTrack.Object, _mockSideOfTrack.Object, new Mock<IBorderOfTrack>().Object));
            _sut.Next.Should().NotBeNull();
        }
    }
}