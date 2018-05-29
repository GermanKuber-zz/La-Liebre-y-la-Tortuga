using System;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Types.BetCards;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Types.BetCards
{
    public class BetCardsPlayerManagerShould 
    {
        private readonly IBetCardsPlayerManager _sut;

        public BetCardsPlayerManagerShould()
        {
            _sut =  BetCardsPlayerManager.Create();
        }
        [Fact]
        public void Accept_One_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(1);
        }

        [Fact]
        public void Accept_Two_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(2);
        }

        [Fact]
        public void Produced_Error_Doest_Not_Accept_More_Than_Three_BetCards()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            Action act = () => _sut.GiveCard(new Mock<IBetCard>().Object);

            act.Should().Throw<ArgumentException>();
        }
    }
}