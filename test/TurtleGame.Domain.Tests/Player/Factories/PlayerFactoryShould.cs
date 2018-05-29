using FluentAssertions;
using Moq;
using TurtleGame.Domain.Player.Factories;
using TurtleGame.Domain.Player.Factories.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Factories
{
    public class PlayerFactoryShould
    {
        private readonly Mock<ChooseSideOfTrackDelagate> _mockChoseSideOfTrack
            = new Mock<ChooseSideOfTrackDelagate>();
        private readonly Mock<SelectRacingCardDelagate> _mockselectRacingCardInCardsTurn
        = new Mock<SelectRacingCardDelagate>();
        private readonly Mock<ChooseSecondBetDelagate> _mockChooseSecondBet
            = new Mock<ChooseSecondBetDelagate>();
        private readonly IPlayerFactory _sut;

        public PlayerFactoryShould()
        {
            var mockRacingCardManager = new Mock<IRacingCardManager>();
            _sut = new PlayerFactory(mockRacingCardManager.Object);
        }

        [Fact]
        private void Create_Regular_Player()
        {
            _sut.Create(_mockChoseSideOfTrack.Object, _mockChooseSecondBet.Object,
                _mockselectRacingCardInCardsTurn.Object).Should().BeOfType<RegularPlayer>();
        }
    }
}
