using System.Collections.Generic;
using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager
    {
        int NumberOfPlayers { get; }
        IPlayersManager GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards);
        IPlayersManager GiveRaicingCards();
    }
}