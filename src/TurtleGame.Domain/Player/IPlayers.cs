using System;
using System.Collections.Generic;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public interface IPlayers : IEnumerable<IPlayers>, IEnumerator<IPlayers>
    {
        void Each(Action<IPlayer> eachCallBack);
        void Each(Action<IPlayer> eachCallBack, int quantityOfEach);
        void Each(Action<IPlayer, int> eachCallBack, int quantityOfEach);
    }
}