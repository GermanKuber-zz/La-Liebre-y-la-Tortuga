using System;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class PlayerShould
    {
        private Player _sut;
        public PlayerShould()
        {
            _sut = new Player();
        }
    }

    public class TrackShoud
    {
        private TrackBase _sut;

        public TrackShoud()
        {
            var lineWay = new SideOfTrack(true, true, false, false);
            var lineToLeftWay = new SideOfTrack(true, false, true, false);
            _sut = new CommonTrack(lineWay, lineToLeftWay);
        }

        [Fact]
        public void Choose_Side()
        {

        }
    }
}