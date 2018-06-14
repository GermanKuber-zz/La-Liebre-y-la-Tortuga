using TurtleGame.Domain.Tracks;

namespace TurtleGame.Domain.Animals.Types
{
    public class LambAnimal : Animal
    {
        public LambAnimal(ITrackContainerToPlays track) : base(track)
        {
        }
    }
}