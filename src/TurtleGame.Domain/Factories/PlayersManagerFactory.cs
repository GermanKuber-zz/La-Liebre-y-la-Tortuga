using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(playerOne, playerTwo);
        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(playerOne, playerTwo, playerThree);
        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            => new PlayersManager(playerOne, playerTwo, playerFour);
        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(playerOne, playerTwo, playerThree, playerFour, playerFive);
    }
}