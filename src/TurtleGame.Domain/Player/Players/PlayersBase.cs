using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Players.Interfaces;
using TurtleGame.Domain.Player.Types;

namespace TurtleGame.Domain.Player.Players
{
    public abstract class PlayersBase : IPlayers
    {
      
        public abstract void GiveCards(IReadOnlyCollection<IBetCard> betsCards);
        public abstract void TakeCard();

        public abstract int NumberOfPlayers { get; }
        public virtual IPlayer PlayerOne => NonePlayer.Create;
        public virtual IPlayer PlayerTwo => NonePlayer.Create;
        public virtual IPlayer PlayerThree => NonePlayer.Create;
        public virtual IPlayer PlayerFour => NonePlayer.Create;
        public virtual IPlayer PlayerFive => NonePlayer.Create;


    }
}