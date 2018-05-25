using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies;
using Xunit;

namespace TurtleGame.SharedKernel.Tests.Strategies
{
    public class RandomMixStrategyShould
    {
        private readonly RandomMixStrategy _sut;

        public RandomMixStrategyShould()
        {
            _sut = new RandomMixStrategy();
        }

        [Theory]
        [InlineData(45)]
        [InlineData(21)]
        private void Return_Numbers_In_Different_Position(int countOfValues)
        {
            var listOfRacingCards = EnumerableGenerator.Generate(countOfValues, (index) => index);

            listOfRacingCards.SequenceEqual(_sut.Mix(listOfRacingCards)).Should().Be(false);
        }
    }
}