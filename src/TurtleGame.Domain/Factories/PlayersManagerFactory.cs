using System.Collections.Generic;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.SharedKernel.Strategies;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {

        private readonly IGenericMixStrategy _genericMixStrategy;
        private readonly IRacingCardManager _racingCardManager;

        public PlayersManagerFactory(IGenericMixStrategy genericMixStrategy,
            IRacingCardManager racingCardManager)
        {
            _genericMixStrategy = genericMixStrategy;
            _racingCardManager = racingCardManager;
        }
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(
                new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo
            }))), _racingCardManager,
                _genericMixStrategy);

        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree
                      }))), _racingCardManager,
                _genericMixStrategy);

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree, playerFour
                     }))), _racingCardManager,
                _genericMixStrategy);

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
                {
                    playerOne, playerTwo, playerThree, playerFour, playerFive
                           }))), _racingCardManager,
                _genericMixStrategy);
    }
}