using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals.Types
{
    public class LambAnimal : Animal
    {
        public LambAnimal(IReadOnlyCollection<ITrackContainerToPlay> track) : base(track)
        {
        }
    }
}