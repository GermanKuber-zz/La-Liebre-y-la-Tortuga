using System.Collections.Generic;
using Moq;
using TurtleGame.Domain.Animals;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Animals
{
    public class AnimalManagerShould
    {
        private readonly IAnimalManager _sut;
        private readonly Mock<IReadOnlyCollection<ITrack>> _mockTrack = new Mock<IReadOnlyCollection<ITrack>> { DefaultValue = DefaultValue.Mock };
        public AnimalManagerShould()
        {
            _sut = new AnimalManager(_mockTrack.Object);
        }

        [Fact]
        private void Runs_Animals_With_Raicing_Cards()
        {
            _sut.RunAnimals();
        }
    }
}
