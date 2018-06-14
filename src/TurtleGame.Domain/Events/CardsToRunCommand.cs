using MediatR;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Events
{
    public class CardsToRunCommand : IRequest<bool>
    {
        public IRacingCards RacingCardsToRun { get; }

        public CardsToRunCommand(IRacingCards racingCardsToRun)
        {
            RacingCardsToRun = racingCardsToRun;
        }

    }
}