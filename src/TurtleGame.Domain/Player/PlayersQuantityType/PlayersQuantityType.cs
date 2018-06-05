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
        private IPlayers _players;
        public int NumberOfPlayers => _players.Count();
        public IPlayer CurrentFirstPlayer { get; private set; }

        public PlayersQuantityType(IPlayers players)
        {
            _players = players;
            CurrentFirstPlayer = players.First();
        }

        public void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            if (_players.Count().Equals(2))
                _players.Each((player, index) => player.GiveCard(betsCards.ToList()[index]), 2);
            else
                _players.Each((player, index) => player.GiveCard(betsCards.ToList()[index]), 1);
        }

        public void TakeCard() => _players.Each(x => x.TakeRacingCard());
        public void ChooseSecondBet() => _players.Each(x => x.ChooseSecondBet());
        public void CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback)
        {
            if (!_players.MoveNext())
            {
                _players.Reset();
                _players.MoveNext();
            }
            _players.Current.CardsTurn(cardsTurnCallback);
        }

        public void ChangeFirstPlayer()
        {
            CurrentFirstPlayer = _players.GiveMeNextTo(CurrentFirstPlayer);
        }
    }
}