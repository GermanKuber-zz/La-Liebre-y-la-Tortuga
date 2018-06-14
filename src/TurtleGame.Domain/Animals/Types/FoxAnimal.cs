using System.Collections.Generic;
using TurtleGame.Domain.Animals.Types;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Anajajimals.Types
{
    public class FoxAnimal : Animal
    {


        public FoxAnimal(IReadOnlyCollection<ITrackContainerToPlay> track) : base(track)
        {
        }
    }
}