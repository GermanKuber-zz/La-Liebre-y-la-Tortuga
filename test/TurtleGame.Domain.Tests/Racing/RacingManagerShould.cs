using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;
using Xunit;

namespace TurtleGame.Domain.Racing
{
    public class RacingManagerShould
    {
        private RacingManager _sut;
        private Mock<IRacingCardOnDeskManager> _racingCardOnDeskManager =
                                                        new Mock<IRacingCardOnDeskManager> { DefaultValue = DefaultValue.Mock };
        public RacingManagerShould()
        {
            _sut = new RacingManager(_racingCardOnDeskManager.Object);
        }

        [Fact]
        private void Get_All_Card_In_Deskt() {
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
