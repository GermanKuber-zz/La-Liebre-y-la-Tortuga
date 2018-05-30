using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class NonePlayer : IPlayer
    {
        public static NonePlayer Create => new NonePlayer();
        public int BetCardsQuantity => 0;

        public void GiveCard(IBetCard betCard)
        {

        }

        public void TakeRacingCard()
        {
        }

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => default(ISideBoderSelected);

        public bool CardsTurn(SelectedCardsConfirmationDelegate selectedCardsConfirmation) => true;

        public void ChooseSecondBet() { }
        public IRacingCards RacingCards { get; } = Domain.RacingCards.RacingCards.Create(new List<IRacingCard>());

        public IRacingCards MyRacingCards => Domain.RacingCards.RacingCards.Create(new List<IRacingCard>());
    }
}