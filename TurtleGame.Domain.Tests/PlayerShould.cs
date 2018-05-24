using System;
using FluentAssertions;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class PlayerShould
    {
        private Player _sut;

        [Fact]
        public void Not_Allow_Create_Without_Parameters()
        {
            Action act = () => { _sut = new Player(null); };

            act.Should().Throw<ArgumentException>();
        }
    }
}