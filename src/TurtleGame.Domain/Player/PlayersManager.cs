using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Player
{
    public class PlayersManager : IPlayersManager
    {
        private readonly IGenericMixStrategy _mixStrategy;
        private readonly IPlayersQuantityType _players;
        private readonly IRacingCardManager _racingCardManager;

        public int NumberOfPlayers => _players.NumberOfPlayers;

        public PlayersManager(IPlayersQuantityType players,
                              IRacingCardManager racingCardManager,
                              IGenericMixStrategy mixStrategy)
        {
            _mixStrategy = mixStrategy;
            _players = players;
            _racingCardManager = racingCardManager;
        }
        public IPlayersManagerSecondStep GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            if (beatsCards == null || beatsCards.Count != 5)
                throw new ArgumentException(nameof(beatsCards));

            _players.GiveCards(_mixStrategy.Mix(beatsCards.ToList()).ToList());
            return this;
        }
        public IPlayersManagerThirdStep GiveRaicingCards()
        {
            Enumerable.Range(1, 7)
                .ToList()
                .ForEach(x => _players.TakeCard());
            return this;
        }

        public IPlayersManager ChooseSecondBet()
        {
            Enumerable.Range(1, 1)
                .ToList()
                .ForEach(x => _players.ChooseSecondBet());
            return this;
        }

        public IReadyToRaceFourthStep CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback,
                                         DeskIsValidForTheNextPlayerDelegate deskIsValidForTheNextPlayerCallback)
        {
            var validForTheNextPlayer = true;
            while (validForTheNextPlayer)
            {
                _players.CardsTurn(cardsTurnCallback);
                validForTheNextPlayer = deskIsValidForTheNextPlayerCallback();
            }
            return this;
        }

        public void StartRace()
        {
        }
    }
}