using System.Collections.Generic;
using System.Collections.ObjectModel;
using MediatR;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.Domain.Tracks;

namespace TurtleGame.Domain
{

    public class BoardGame
    {
        public static IMediator Mediator { get; set; }
        public ITrackManager Tracks { get; set; }
        public IPlayersManager Players { get; private set; }
        public IRacingCardOnDeskManager RaicingCardsOnDesk { get; set; }

        public IReadOnlyCollection<IBetCard> BetCards => new ReadOnlyCollection<IBetCard>(_beatsCards);

        private readonly IList<IBetCard> _beatsCards;

        #region Constructors

        public BoardGame()
        {
            _beatsCards = new List<IBetCard> { new FoxBetCard(), new HareBetCard(), new LambBetCard(), new TurtleBetCard(), new WolfBetCard() };
        }
        public BoardGame(IPlayer playerOne, 
            IPlayer playerTwo,
            IPlayersManagerFactory playersManagerFactory,
            IRacingCardOnDeskManager racingCardManager) : this()
        {
            Players = playersManagerFactory.ToTwoPlayer(playerOne, playerTwo);
            RaicingCardsOnDesk = racingCardManager;
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayersManagerFactory playersManagerFactory, IRacingCardOnDeskManager racingCardManager) : this()
        {
            Players = playersManagerFactory.ToThreePlayer(playerOne, playerTwo, playerThree);
            RaicingCardsOnDesk = racingCardManager;
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayersManagerFactory playersManagerFactory, IRacingCardOnDeskManager racingCardManager) : this()
        {
            Players = playersManagerFactory.ToFourPlayer(playerOne, playerTwo, playerThree, playerFour);
            RaicingCardsOnDesk = racingCardManager;
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive, IPlayersManagerFactory playersManagerFactory, IRacingCardOnDeskManager racingCardManager) : this()
        {
            Players = playersManagerFactory.ToFivePlayer(playerOne, playerTwo, playerThree, playerFour, playerFive);
            RaicingCardsOnDesk = racingCardManager;
        }

        #endregion

        public void Start()
        {
            Players.GiveBetCards(BetCards)
                   .GiveRaicingCards()
                   .ChooseSecondBet()
                   .CardsTurn(x => RaicingCardsOnDesk.FallCardsToDeck(x),
                             () => RaicingCardsOnDesk.IsValid());
        }

    }
}