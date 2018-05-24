using System.Collections.Generic;

namespace TurtleGame.Domain
{
    public class TracksFactory : ITracksFactory
    {
        public List<ITrack> GetTracks()
        {
            var lineWay = new SideOfTrack(true, true, false, false);
            var lineToLeftWay = new SideOfTrack(true, false, true, false);
            return new List<ITrack>
            {
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new CommonTrack(lineWay, lineToLeftWay),
                new TrackWithStream(lineWay, lineToLeftWay),
                new TrackWithStream(lineWay, lineToLeftWay),
                new TrackWithStream(lineWay, lineToLeftWay),
                new TrackWithStream(lineWay, lineToLeftWay),

            };
        }
    }
}