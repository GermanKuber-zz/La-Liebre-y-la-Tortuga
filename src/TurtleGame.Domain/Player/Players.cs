using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Common;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player
{
    public class Players : EntitiesCollectionsBase<IPlayer>, IPlayers
    {
        public Players(IEnumerable<IPlayer> players) : base(players.ToList())
        {
            
        }

       
    }
}

