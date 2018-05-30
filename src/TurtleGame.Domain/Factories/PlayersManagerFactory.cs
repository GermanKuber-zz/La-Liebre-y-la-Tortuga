using System.Collections.Generic;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.RacingCards;
using TurtleGame.SharedKernel.Strategies;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Factories
{
    public class PlayersManagerFactory : IPlayersManagerFactory
    {

        private readonly IGenericMixStrategy _genericMixStrategy;
        private readonly IRacingCardsFactory _racingCardsFactory;

        public PlayersManagerFactory(IGenericMixStrategy genericMixStrategy,
            IRacingCardsFactory racingCardsFactory)
        {
            _genericMixStrategy = genericMixStrategy;
            _racingCardsFactory = racingCardsFactory;
        }
        public IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo)
            => new PlayersManager(
                new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo
            }))), new RacingCardManager(_racingCardsFactory, new RandomMixStrategy()), new RandomMixStrategy());

        public IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree
            }))), new RacingCardManager(_racingCardsFactory, new RandomMixStrategy()), new RandomMixStrategy());

        public IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
            {
                playerOne, playerTwo, playerThree, playerFour
            }))), new RacingCardManager(_racingCardsFactory, new RandomMixStrategy()), new RandomMixStrategy());

        public IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree,
            IPlayer playerFour, IPlayer playerFive)
            => new PlayersManager(new PlayersQuantityType(new Players(_genericMixStrategy.Mix(new List<IPlayer>
                {
                    playerOne, playerTwo, playerThree, playerFour, playerFive
                })))
                , new RacingCardManager(_racingCardsFactory, new RandomMixStrategy()), new RandomMixStrategy());
    }
}