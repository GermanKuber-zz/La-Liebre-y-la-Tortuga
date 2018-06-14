using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals.Types
{
    public class TurtleAnimal : Animal
    {
        public TurtleAnimal(IReadOnlyCollection<ITrackContainerToPlay> track)   :base(track)
        {
        }
    }
}