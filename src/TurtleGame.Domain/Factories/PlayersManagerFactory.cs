using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Players;
using TurtleGame.SharedKernel.Strategies;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {
      
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(new TwoPlayers(playerOne, playerTwo), new RandomMixStrategy());
        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new ThreePlayers(playerOne, playerTwo, playerThree), new RandomMixStrategy());

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new FourPlayers(playerOne, playerTwo, playerThree, playerFour), new RandomMixStrategy());

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new FivePlayers(playerOne, playerTwo, playerThree, playerFour, playerFive)
                , new RandomMixStrategy());
    }
}