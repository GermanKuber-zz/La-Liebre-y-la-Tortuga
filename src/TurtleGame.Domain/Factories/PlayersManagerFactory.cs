using System.Collections.Generic;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.SharedKernel.Strategies;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {

        private readonly IGenericMixStrategy _genericMixStrategy;

        public PlayersManagerFactory(IGenericMixStrategy genericMixStrategy)
        {
            _genericMixStrategy = genericMixStrategy;
        }
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo
            }))), new RandomMixStrategy());

        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree
            }))), new RandomMixStrategy());

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree, playerFour
            }))), new RandomMixStrategy());

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
                {
                    playerOne, playerTwo, playerThree, playerFour, playerFive
                })))
                , new RandomMixStrategy());
    }
}