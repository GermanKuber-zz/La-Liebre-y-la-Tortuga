using System.Collections.Generic;
using MediatR;
using Moq;
using TurtleGame.Domain.Racing;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.Domain.RacingCards.Types;
using TurtleGame.Domain.Tracks;
using Xunit;

namespace TurtleGame.Domain.Tests.Racing
{
    public class RacingManagerShould
    {
        private RacingManager _sut;
        private Mock<IRacingCardOnDeskManager> _racingCardOnDeskManager =
                                                        new Mock<IRacingCardOnDeskManager> { DefaultValue = DefaultValue.Mock };
        private Mock<ITrackManager> _mockITrackManager = new Mock<ITrackManager> { DefaultValue = DefaultValue.Mock };
        public RacingManagerShould()
        {
            _sut = new RacingManager(_racingCardOnDeskManager.Object,
                                     _mockITrackManager.Object);
            BoardGame.Mediator = new Mock<IMediator>() { DefaultValue = DefaultValue.Mock }.Object;
        }

        [Fact]
        private void Get_All_Card_In_Deskt()
        {
            _sut.StartRace();
            _racingCardOnDeskManager.Verify(x => x.TakeAllDesktCard(), Times.Once);
        }

        [Fact]
        private void Fall_Racing_Cards_To_Discart_List()
        {

            _racingCardOnDeskManager.SetupSequence(x => x.TakeAllDesktCard())
                                    .Returns(new List<IRacingCard> { new Mock<WolfRacingCard>().Object,
                                                                     new Mock<WolfRacingCard>().Object,
                                                                     new Mock<TurtleRacingCard>().Object,
                                                                     new Mock<LambRacingCard>().Object});

            _sut.StartRace();
            _racingCardOnDeskManager.Verify(x => x.FallCardsToDeck(It.IsAny<IRacingCards>()), Times.Exactly(3));
        }


    }
}
