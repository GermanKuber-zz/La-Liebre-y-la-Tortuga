using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals.Types
{
    public abstract class Animal
    {
        protected IReadOnlyCollection<ITrackContainerToPlay> Track;
        protected Animal(IReadOnlyCollection<ITrackContainerToPlay> track)
        {
            Track = track;
        }
    }
}