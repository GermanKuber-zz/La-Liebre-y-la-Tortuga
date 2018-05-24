using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TurtleGame.Domain
{
    public class PlaceTrackRandomStrategy : IPlaceTrackStrategy
    {
        public ReadOnlyCollection<ITrack> PlaceTracks(List<ITrack> tracksToPlace)
        {
            var random = new Random();
            var localCount = Enumerable.Range(0, tracksToPlace.Count).ToList();
            var tmpList = new List<ITrack>();
            while (localCount.Count() != 0)
            {
                var randomIndex = random.Next(0, localCount.Count());
                tmpList.Add(tracksToPlace[localCount[randomIndex]]);
                localCount.RemoveAt(randomIndex);
            }
            return new ReadOnlyCollection<ITrack>(tmpList);
        }
    }

    public class DecideSideFactory : IDecideSideFactory
    {
        public DecideSideChain Create()
        {
            var decideMaxCountUpSideChain = new DecideMaxCountUpSideChain();
            var decideMaxCountDownSideChain = new DecideMaxCountDownSideChain();
            var decideSameCountSideChain = new DecideSameCountSideChain();
            decideMaxCountUpSideChain.SetSuccessor(decideMaxCountDownSideChain);
            decideMaxCountDownSideChain.SetSuccessor(decideSameCountSideChain);
            return decideMaxCountUpSideChain;
        }
    }
}