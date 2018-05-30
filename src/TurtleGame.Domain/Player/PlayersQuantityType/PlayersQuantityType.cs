using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{

    public class PlayersQuantityType : IPlayersQuantityType
    {
        public IPlayers Players { get; }

        public int NumberOfPlayers => Players.Count();


        public PlayersQuantityType(IPlayers players)
        {
            Players = players;
        }

        public void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            if (Players.Count().Equals(2))
                Players.Each((player, index) => player.GiveCard(betsCards.ToList()[index]), 2);
            else
                Players.Each((player, index) => player.GiveCard(betsCards.ToList()[index]), 1);

        }

        public void TakeCard() => Players.Each(x => x.TakeRacingCard());
        public void ChooseSecondBet() => Players.Each(x => x.ChooseSecondBet());
        public void CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback) {
            if (!Players.MoveNext()) { 
                Players.Reset();
                Players.MoveNext();
            }

            Players.Current.CardsTurn(cardsTurnCallback);
        } 
    }
}