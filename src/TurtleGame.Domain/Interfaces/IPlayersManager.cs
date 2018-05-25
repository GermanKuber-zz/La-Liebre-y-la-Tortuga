using System.Collections.Generic;
using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager
    {
        int NumberOfPlayers { get; }
        IPlayer PlayerFive { get; }
        IPlayer PlayerFour { get; }
        IPlayer PlayerThree { get; }
        IPlayer PlayerOne { get; }
        IPlayer PlayerTwo { get; }
        void GiveCards(IReadOnlyCollection<IBetCard> beatsCards);
    }
}