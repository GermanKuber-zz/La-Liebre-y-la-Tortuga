using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Animals;
using TurtleGame.Domain.Animals.Types;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Animals
{
    public class AnimalManagerShould
    {
        private IAnimalManager _sut;
        private readonly Mock<ITrackContainerToPlays> _mockTrack = new Mock<ITrackContainerToPlays> { DefaultValue = DefaultValue.Mock };
        private readonly Mock<IAnimals> _mockAnimals =
                        new Mock<IAnimals> { DefaultValue = DefaultValue.Mock };
        public AnimalManagerShould()
        {
            _sut = new AnimalManager(_mockTrack.Object, _mockAnimals.Object);
        }

        [Fact]
        private void Runs_Animals_With_Raicing_Cards()
        {
            _sut.RunAnimals();
        }
        [Fact]
        private void Start_All_Animals_In_The_First_Track()
        {
            var trackContainerToPlays = new TrackContainerToPlays(new List<ITrackContainerToPlay>
            {
                new Mock<ITrackContainerToPlay>().Object,
                new Mock<ITrackContainerToPlay>().Object,
                new Mock<ITrackContainerToPlay>().Object
            });
            var fox = new FoxAnimal(trackContainerToPlays);
            var hare = new HareAnimal(trackContainerToPlays);
            var lamb = new LambAnimal(trackContainerToPlays);
            var turtle = new TurtleAnimal(trackContainerToPlays);
            var animals = new Domain.Animals.Animals(new ReadOnlyCollection<Animal>(new List<Animal>
            {
                fox,
                hare,
                lamb,
                turtle
            }));

            _sut = new AnimalManager(trackContainerToPlays, animals);
            fox.CurrentTrack.Should().Be(hare.CurrentTrack);
        }

    }
}
