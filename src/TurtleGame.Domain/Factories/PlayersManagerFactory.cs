using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.SharedKernel.Strategies;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {
      
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(new TwoPlayersQuantityType(playerOne, playerTwo), new RandomMixStrategy());
        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new ThreePlayersQuantityType(playerOne, playerTwo, playerThree), new RandomMixStrategy());

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new FourPlayersQuantityType(playerOne, playerTwo, playerThree, playerFour), new RandomMixStrategy());

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new FivePlayersQuantityType(playerOne, playerTwo, playerThree, playerFour, playerFive)
                , new RandomMixStrategy());
    }
}