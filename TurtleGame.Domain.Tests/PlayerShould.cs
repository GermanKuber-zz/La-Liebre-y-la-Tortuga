using System;

namespace TurtleGame.Domain.Tests
{
    public class PlayerShould
    {
        private Player _sut;
        public PlayerShould()
        {
            _sut = new Player();
        }

        //[Fact]
        //public void Keep_BetCard_Without_See_It()
        //{
        //    var mockCard = new Mock<IBetCard>();
        //    _sut.GiveCard(mockCard.Object);
        //    _sut.Should().Throw<ArgumentException>();
        //}

    }
}