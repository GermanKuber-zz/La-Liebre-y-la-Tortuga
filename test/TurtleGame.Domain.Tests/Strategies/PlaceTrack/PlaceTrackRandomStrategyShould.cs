using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;

namespace TurtleGame.Domain.Tests.Strategies.PlaceTrack
{
    public class PlaceTrackRandomStrategyShould
    {
        private readonly PlaceTrackRandomStrategy _sut;

        public PlaceTrackRandomStrategyShould()
        {
            _sut = new PlaceTrackRandomStrategy();
        }

        [Fact]
        public void Returns_Same_Quantity_Plus_One_Of_Track_That_Recived()
        {
            var resultThreeTracks = _sut.PlaceTracks(new List<ITrack>
            {
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object
            });
            resultThreeTracks.Count.Should().Be(4);
        }

        [Fact]
        public void First_Track_Be_Starting_Track()
        {
            var resultThreeTracks = _sut.PlaceTracks(new List<ITrack>
            {
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object
            });
            resultThreeTracks.First().Should().BeOfType<StartingLineTrack>();
        }
    }
}
