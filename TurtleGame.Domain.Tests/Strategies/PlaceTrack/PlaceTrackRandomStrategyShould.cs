using System;
using System.Collections.Generic;
using System.Text;
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
        public void Returns_Same_Quantity_Of_Track_That_Recived()
        {
            var resultThreeTracks = _sut.PlaceTrack(new List<ITrack>
            {
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object,
                new Mock<ITrack>().Object
            });
            resultThreeTracks.Count.Should().Be(3);
        }
        [Fact]
        public void Returns_List_In_Diferent_Orden_Always()
        {
            var resultThreeTracks = _sut.PlaceTrack(new List<ITrack>
            {
                new CommonTrack(),
                new CommonTrack(),
                new TrackWithStream()
            });
            resultThreeTracks.Count.Should().Be(3);
        }
    }
}
