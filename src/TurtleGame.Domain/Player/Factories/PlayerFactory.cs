using System;
using TurtleGame.Domain.Player.Factories.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRacingCardManager _racingCardManager;

        public PlayerFactory(IRacingCardManager racingCardManager)
        {
            _racingCardManager = racingCardManager;
        }
        public IPlayer Create(Func<ITrack, ISideBoderSelected> choseSideOfTrack) =>
            new RegularPlayer(choseSideOfTrack, _racingCardManager);

    }
}
