using TurtleGame.Domain.Tracks;

namespace TurtleGame.Domain.Animals
{
    public class AnimalManager : IAnimalManager
    {
        private readonly ITrackContainerToPlays _track;
        private readonly IAnimals _animals;
        public AnimalManager(ITrackContainerToPlays track, IAnimals animals)
        {
            _track = track;
            _animals = animals;

            _animals.Each(x => x.PrepareToStart());
        }

        public void RunAnimals()
        {
            _animals.Each(x => x.Run());
        }
    }
}
