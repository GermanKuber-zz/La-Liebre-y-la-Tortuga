using System.Collections.Generic;
using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayersManager : IPlayersManagerFirstStep, IPlayersManagerSecondStep, IPlayersManagerThirdStep
    {
        int NumberOfPlayers { get; }

    }
    public interface IPlayersManagerFirstStep
    {
        IPlayersManagerSecondStep GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards);
    }
    public interface IPlayersManagerSecondStep
    {
        IPlayersManagerThirdStep GiveRaicingCards();
    }
    public interface IPlayersManagerThirdStep
    {
        IPlayersManager ChooseSecondBet();
    }

   
}