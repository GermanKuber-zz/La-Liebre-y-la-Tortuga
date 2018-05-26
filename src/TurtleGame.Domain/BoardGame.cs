using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain
{

    public class BoardGame
    {
        public IPlayersManager Players { get; private set; }
        public IReadOnlyCollection<IBetCard> BetCards => new ReadOnlyCollection<IBetCard>(_beatsCards);

        private readonly IList<IBetCard> _beatsCards;

        #region Constructors

        public BoardGame()
        {
            _beatsCards = new List<IBetCard> { new Fox(), new Hare(), new Lamb(), new Turtle(), new Wolf() };
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayersManagerFactory playersManagerFactory)
        {
            Players = playersManagerFactory.ToTwoPlayer(playerOne, playerTwo);
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayersManagerFactory playersManagerFactory)
        {
            Players = playersManagerFactory.ToThreePlayer(playerOne, playerTwo, playerThree);
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayersManagerFactory playersManagerFactory)
        {
            Players = playersManagerFactory.ToFourPlayer(playerOne, playerTwo, playerThree, playerFour);

        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive, IPlayersManagerFactory playersManagerFactory)
        {
            Players = playersManagerFactory.ToFivePlayer(playerOne, playerTwo, playerThree, playerFour, playerFive);
        }

        #endregion

        public void Start()
        {
            Players.GiveBetCards(BetCards)
                   .GiveRaicingCards();
        }

    }
}