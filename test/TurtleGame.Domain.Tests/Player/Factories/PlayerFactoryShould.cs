using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using TurtleGame.Domain.Player.Factories.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Player.Factories
{
    public class PlayerFactoryShould
    {
        private Mock<IRacingCardManager> _mockRacingCardManager;
        private Mock<Func<ITrack, ISideBoderSelected>> _mockChoseSideOfTrack
            = new Mock<Func<ITrack, ISideBoderSelected>>();

        private Mock<Func<IReadOnlyCollection<IRacingCard>, IRacingCard>> _mockChooseSecondBet
            = new Mock<Func<IReadOnlyCollection<IRacingCard>, IRacingCard>>();
        private IPlayerFactory _sut;

        public PlayerFactoryShould()
        {
            _mockRacingCardManager = new Mock<IRacingCardManager>();
            _sut = new PlayerFactory(_mockRacingCardManager.Object);
        }

        [Fact]
        private void Create_Regular_Player()
        {
            _sut.Create(_mockChoseSideOfTrack.Object, _mockChooseSecondBet.Object).Should().BeOfType<RegularPlayer>();
        }
    }
}
