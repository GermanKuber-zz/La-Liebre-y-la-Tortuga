using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Player.Players.Interfaces
{
    public interface IPlayers
    {
        void GiveCards(IReadOnlyCollection<IBetCard> betsCards);
        void TakeCard();
        int NumberOfPlayers { get; }
        IPlayer PlayerFive { get; }
        IPlayer PlayerFour { get; }
        IPlayer PlayerOne { get; }
        IPlayer PlayerThree { get; }
        IPlayer PlayerTwo { get; }
    }
}