using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Factories
{
    public class BoardGameFactory : IBoardGameFactory
    {
        private readonly IPlayersManagerFactory _playersManagerFactory;
        private readonly IRacingCardOnDeskManager _racingCardManager;

        public BoardGameFactory(IPlayersManagerFactory playersManagerFactory, IRacingCardOnDeskManager racingCardManager)
        {
            _playersManagerFactory = playersManagerFactory;
            _racingCardManager = racingCardManager;
        }
        public BoardGame ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new BoardGame(playerOne, playerTwo, _playersManagerFactory, _racingCardManager);
        public BoardGame ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerThree, _playersManagerFactory, _racingCardManager);
        public BoardGame ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new BoardGame(playerOne, playerTwo, playerFour, _playersManagerFactory, _racingCardManager);
        public BoardGame ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive)
            => new BoardGame(playerOne, playerTwo, playerThree, playerFour, playerFive, _playersManagerFactory, _racingCardManager);
    }
}