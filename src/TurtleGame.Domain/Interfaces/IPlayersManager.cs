using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Players.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager
    {
        IPlayers Players { get; }
        void GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards);
        void GiveRaicingsCard();
    }
}