using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals.Types
{
    public class HareAnimal : Animal
    {
      

        public HareAnimal(IReadOnlyCollection<ITrackContainerToPlay> track) : base(track)
        {
        }
    }
}