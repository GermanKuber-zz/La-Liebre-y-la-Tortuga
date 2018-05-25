using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Types;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(new TwoPlayers(playerOne, playerTwo));
        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new ThreePlayers(playerOne, playerTwo, playerThree));

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new FourPlayers(playerOne, playerTwo, playerThree, playerFour));

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new FivePlayers(playerOne, playerTwo, playerThree, playerFour, playerFive));
    }
}