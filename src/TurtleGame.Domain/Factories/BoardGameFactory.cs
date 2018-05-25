using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Factories
{
    public class BoardGameFactory : IBoardGameFactory
    {
        private readonly IPlayersManagerFactory _playersManagerFactory;

        public BoardGameFactory(IPlayersManagerFactory playersManagerFactory)
        {
            _playersManagerFactory = playersManagerFactory;
        }
        public BoardGame ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new BoardGame(playerOne, playerTwo, _playersManagerFactory);
        public BoardGame ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerThree, _playersManagerFactory);
        public BoardGame ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerFour, _playersManagerFactory);
        public BoardGame ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive)
            => new BoardGame(playerOne, playerTwo, playerThree, playerFour, playerFive, _playersManagerFactory);
    }
}