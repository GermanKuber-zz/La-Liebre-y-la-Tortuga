using TurtleGame.Domain.Tracks;

namespace TurtleGame.Domain.Animals.Types
{
    public class TurtleAnimal : Animal
    {
        public TurtleAnimal(ITrackContainerToPlays track)   :base(track)
        {
        }
    }
}