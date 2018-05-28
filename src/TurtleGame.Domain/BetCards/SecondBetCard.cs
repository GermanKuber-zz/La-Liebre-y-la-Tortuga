using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.BetCards
{

    public class SecondBetCard : IBetCard {
        private readonly IRacingCard _racingCard;

        public SecondBetCard(IRacingCard racingCard)
        {
            _racingCard = racingCard;
        }
    }
}