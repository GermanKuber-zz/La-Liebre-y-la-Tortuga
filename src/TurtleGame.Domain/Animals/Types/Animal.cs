using TurtleGame.Domain.Tracks;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Animals.Types
{
    public abstract class Animal
    {
        public ITrackContainerToPlay CurrentTrack;
        protected ITrackContainerToPlays Track;
        protected Animal(ITrackContainerToPlays track)
        {
            Track = track;
        }

        public void PrepareToStart()
        {
            Track.Reset();
            if (Track.MoveNext())
                CurrentTrack = Track.Current;
        }

        public void Run()
        {
        }
    }
}