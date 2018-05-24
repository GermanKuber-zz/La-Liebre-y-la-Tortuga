using System;
using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain
{
    public class BoardGame
    {
        private readonly IPlayer _playerFive;
        private readonly IPlayer _playerFour;
        private readonly IPlayer _playerThree;
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;

        public static BoardGame ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new BoardGame(playerOne, playerTwo);
        public static BoardGame ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerThree);
        public static BoardGame ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerFour);
        public static BoardGame ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive)
            => new BoardGame(playerOne, playerTwo, playerThree, playerFour, playerFive);

        protected BoardGame(IPlayer playerOne, IPlayer playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            NumberOfPlayers = 2;
        }
        protected BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree) : this(playerOne, playerTwo)
        {
            _playerThree = playerThree;
            NumberOfPlayers = 3;
        }
        protected BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour) : this(playerOne, playerTwo, playerThree)
        {
            _playerFour = playerFour;
            NumberOfPlayers = 4;
        }
        protected BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive) : this(playerOne, playerTwo, playerThree, playerFour)
        {
            _playerFive = playerFive;
            NumberOfPlayers = 5;
        }

        public int NumberOfPlayers { get; private set; }

        public void SetPlayers(int numberOfPlayers)
        {
            if (numberOfPlayers < 2 || numberOfPlayers > 5)
                throw new ArgumentException(nameof(numberOfPlayers));

            NumberOfPlayers = numberOfPlayers;
        }

        public void Start()
        {
            var betCard = new Turtle();
            if (NumberOfPlayers >= 2)
            {
                _playerOne.GiveCard(betCard);
                _playerTwo.GiveCard(betCard);
            }
            if (NumberOfPlayers >= 3)
                _playerThree.GiveCard(betCard);
            if (NumberOfPlayers >= 4)
                _playerFour.GiveCard(betCard);
            if (NumberOfPlayers >= 5)
                _playerFive.GiveCard(betCard);

        }
    }
}