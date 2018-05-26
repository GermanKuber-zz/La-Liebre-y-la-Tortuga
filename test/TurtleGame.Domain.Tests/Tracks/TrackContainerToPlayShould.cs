using System;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Interfaces;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Tracks
{
    public class TrackContainerToPlayShould
    {
        private readonly Mock<SideOfTrackSelector> _mockCurrentSide = new Mock<SideOfTrackSelector>();
        private readonly ITrackContainerToPlay _sut;
        private readonly Mock<ITrack> _mockTrack = new Mock<ITrack>();
        private readonly Mock<ISideOfTrack> _mockSideOfTrack = new Mock<ISideOfTrack>();
        public TrackContainerToPlayShould()
        {
            _mockCurrentSide.SetupAllProperties();
            _sut = new TrackContainerToPlay(new SideBoderSelected(_mockTrack.Object, _mockSideOfTrack.Object, new Mock<IBorderOfTrack>().Object));
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
            _sut.SetNext(new SideBoderSelected(_mockTrack.Object, _mockSideOfTrack.Object, new Mock<IBorderOfTrack>().Object));
            _sut.Next.Should().NotBeNull();
        }
    }
}