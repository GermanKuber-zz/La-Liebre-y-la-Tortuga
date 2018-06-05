using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType.Interfaces
{
    public interface IPlayersQuantityType
    {
        void GiveCards(IReadOnlyCollection<IBetCard> betsCards);
        /// <summary>
        /// Deal one raicing card to each player
        /// </summary>
        void TakeCard();
        int NumberOfPlayers { get; }
        IPlayer CurrentFirstPlayer { get; }
        void ChooseSecondBet();
        void CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback);
        void ChangeFirstPlayer();
    }
}