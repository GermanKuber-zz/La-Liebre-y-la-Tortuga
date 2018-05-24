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

        public TrackManagerShould()
        {
            _mockTrackFactory = new Mock<ITracksFactory>();

            _sut = new TrackManager(_mockTrackFactory.Object);
        }

        [Fact]
        public void Put_Al_Track_In_A_List()
        {
            var mockPlaceTrackStrategy = new Mock<IPlaceTrackStrategy>();
            mockPlaceTrackStrategy.Setup(x => x.PlaceTrack(It.IsAny<List<ITrack>>()))
                .Returns(() => new ReadOnlyCollection<ITrack>(new List<ITrack> { new Mock<ITrack>().Object, new Mock<ITrack>().Object }));
            _sut.PlaceTrack(mockPlaceTrackStrategy.Object);
            _sut.Track.Should().NotBeNull();
        }
    }
}