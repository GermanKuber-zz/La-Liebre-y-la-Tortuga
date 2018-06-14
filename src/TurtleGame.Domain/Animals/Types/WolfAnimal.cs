using System.Collections.Generic;
using TurtleGame.Domain.Animals.Types;
using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Interfaces;
namespace TurtleGame.Domain.Animals
{
    public class WolfAnimal : Animal
    {

        public WolfAnimal(ITrackContainerToPlays track) : base(track)
        {
        }
    }
}