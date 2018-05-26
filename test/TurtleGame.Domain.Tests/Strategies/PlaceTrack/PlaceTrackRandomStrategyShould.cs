using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Tracks.Interfaces;
using TurtleGame.Domain.Tracks.Strategies;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Strategies.PlaceTrack
{
    public class PlaceTrackRandomStrategyShould
    {
        private readonly MixTrackRandomStrategy _sut;
        private readonly Mock<IGenericMixStrategy> _mockGenericMixStrategy;

        public PlaceTrackRandomStrategyShould()
        {
            _mockGenericMixStrategy = new Mock<IGenericMixStrategy>();

            _sut = new MixTrackRandomStrategy(_mockGenericMixStrategy.Object);
        }

        [Fact]
        public void Returns_Same_Quantity_Plus_One_Of_Track_That_Recived()
        {
            var listToMix = new List<ITrack>
            {
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object
            };
            _mockGenericMixStrategy.Setup(x => x.Mix<ITrack>(It.IsAny<List<ITrack>>()))
                .Returns(new ReadOnlyCollection<ITrack>(listToMix));

            var resultThreeTracks = _sut.MixTracks(listToMix);

            resultThreeTracks.Count.Should().Be(3);
        }

      
    }
}
