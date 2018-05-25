using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Types.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public abstract class PlayersBase : IPlayers
    {
        public abstract void GiveCards(IReadOnlyCollection<IBetCard> beatsCards);

        public abstract int NumberOfPlayers { get; }
        public virtual IPlayer PlayerOne => NonePlayer.Create;
        public virtual IPlayer PlayerTwo => NonePlayer.Create;
        public virtual IPlayer PlayerThree => NonePlayer.Create;
        public virtual IPlayer PlayerFour => NonePlayer.Create;
        public virtual IPlayer PlayerFive => NonePlayer.Create;

      
    }
}