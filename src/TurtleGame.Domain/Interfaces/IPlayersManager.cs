using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Types.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager
    {
        IPlayers Players { get; }
        void GiveCards(IReadOnlyCollection<IBetCard> beatsCards);
    }
}