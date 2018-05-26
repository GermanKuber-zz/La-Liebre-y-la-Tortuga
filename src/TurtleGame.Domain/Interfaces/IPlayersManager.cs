using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Players.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager
    {
        IPlayers Players { get; }
        IPlayersManager GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards);
        IPlayersManager GiveRaicingCards();
    }
}