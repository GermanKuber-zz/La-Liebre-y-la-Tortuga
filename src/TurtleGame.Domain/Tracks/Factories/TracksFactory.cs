using System.Collections.Generic;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Types;

namespace TurtleGame.Domain.Tracks.Factories
{
    public class TracksFactory : ITracksFactory
    {
        public List<ITrack> GetTracks()
        {
            var lineWay = new SideOfTrackSelector(true, true, false, false);
            var lineToLeftWay = new SideOfTrackSelector(true, false, true, false);
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