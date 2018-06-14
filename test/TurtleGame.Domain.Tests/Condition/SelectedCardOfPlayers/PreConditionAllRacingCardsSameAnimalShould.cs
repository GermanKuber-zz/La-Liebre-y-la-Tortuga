using Moq;
using TurtleGame.Domain.Condition.SelectedCardOfPlayers;
using TurtleGame.Domain.RacingCards;
using Xunit;

namespace TurtleGame.Domain.Tests.Condition.SelectedCardOfPlayers
{
    public class PreConditionAllRacingCardsSameAnimalShould: PreconditionShouldBase
    {
        private IPreConditionRaicingCards _sut;
        private Mock<IRacingCards> _mockRacingCards = new Mock<IRacingCards>();
        public PreConditionAllRacingCardsSameAnimalShould()
        {
            Sut = new PreConditionAllRacingCardsSameAnimal();
        }

        [Fact]
        private void Validate_Return_Value()
        {
            Sut.Validate(_mockRacingCards.Object);
            _mockRacingCards.Verify(x => x.AllCardAreTheSameAnimal(), Times.Once);
        }
    }

}