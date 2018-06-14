using System;
using System.Collections.Generic;
using System.Text;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IReadOnlyCollection<ITrack> _track;

        public  AnimalManager(IReadOnlyCollection<ITrack> track)
        {
            _track = track;
        }

        public void RunAnimals()
        {
            
        }
    }

    public interface IAnimalManager
    {
        void RunAnimals();
    }
}
