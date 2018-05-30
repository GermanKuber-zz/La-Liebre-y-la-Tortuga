namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCardOnDeskManager
    {
        int QuantityOfCards { get; }

        bool FallCardsToDeck(IRacingCards racingCard);
        bool IsValid();
    }
}