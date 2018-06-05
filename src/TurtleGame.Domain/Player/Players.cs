using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public class Players : EntitiesCollectionsBase<IPlayer>, IPlayers
    {
        public Players(IEnumerable<IPlayer> players) : base(players.ToList())
        {
            
        }

       
    }
}

