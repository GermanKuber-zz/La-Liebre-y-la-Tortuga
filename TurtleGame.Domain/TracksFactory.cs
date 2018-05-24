using System.Collections.Generic;

namespace TurtleGame.Domain
{
    public class TracksFactory : ITracksFactory
    {
        public List<ITrack> GetTracks()=>new List<ITrack>
        {
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new CommonTrack(),
            new TrackWithStream(),
            new TrackWithStream(),
            new TrackWithStream(),
            new TrackWithStream(),

        };
    }
}