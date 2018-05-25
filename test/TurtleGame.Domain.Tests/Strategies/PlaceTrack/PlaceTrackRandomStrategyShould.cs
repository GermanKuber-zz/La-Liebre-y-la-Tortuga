using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Tracks.Strategies;
using Xunit;

namespace TurtleGame.Domain.Tests.Strategies.PlaceTrack
{
    public class PlaceTrackRandomStrategyShould
    {
        private readonly MixTrackRandomStrategy _sut;

        public PlaceTrackRandomStrategyShould()
        {
            _sut = new MixTrackRandomStrategy(new RandomMixStrategy());
        }

        [Fact]
        public void Returns_Same_Quantity_Plus_One_Of_Track_That_Recived()
        {
            var resultThreeTracks = _sut.MixTracks(new List<ITrack>
            {
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object
            });
            resultThreeTracks.Count.Should().Be(3);
        }

      
    }
}
