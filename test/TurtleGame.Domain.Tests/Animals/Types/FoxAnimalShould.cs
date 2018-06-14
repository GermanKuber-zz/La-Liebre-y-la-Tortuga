using System.Collections.Generic;
using System.Linq;
using Moq;
using TurtleGame.Domain.Animals.Types;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Animals.Types
{
    public class FoxAnimalShould
    {
        private readonly Mock<ITrackContainerToPlays> _mocktTrackContainerToPlay =
                            new Mock<ITrackContainerToPlays> { DefaultValue = DefaultValue.Mock };

        private FoxAnimal _sut;

        public FoxAnimalShould()
        {
            _mocktTrackContainerToPlay.SetReturnsDefault(new List<ITrackContainerToPlay>());
            _sut = new FoxAnimal(_mocktTrackContainerToPlay.Object);
           
        }

        [Fact]
        private void Move_To_The_First_Track()
        {
            _sut.PrepareToStart();
        }


    }
}