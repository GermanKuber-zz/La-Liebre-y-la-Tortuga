using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.RacingCards
{

    public class RacingCardsShould
    {
        private IRacingCards _sut;
        private List<IRacingCard> _racingCards = new List<IRacingCard>();
        public RacingCardsShould()
        {
            _racingCards = EnumerableGenerator.Generate<IRacingCard>(5, x =>
            {
                return new Mock<IRacingCard>().Object;
            });

            _sut = Domain.RacingCards.RacingCards.Create(_racingCards);
        }

        [Fact]
        private void Return_True_Each_Animal_Are_The_Same_Type()
        {
            _sut.AllCardAreTheSameAnimal().Should().Be(true);
        }
        [Fact]
        private void Return_False_Are_Diferent_Type_Of_Animals()
        {
            _racingCards = new List<IRacingCard> {
                new Mock<LambRacingCard>().Object,
                  new Mock<HareRacingCard>().Object,
                  new Mock<WolfRacingCard>().Object
             };

            _sut = Domain.RacingCards.RacingCards.Create(_racingCards);

            _sut.AllCardAreTheSameAnimal().Should().Be(false);
        }
    }
}


