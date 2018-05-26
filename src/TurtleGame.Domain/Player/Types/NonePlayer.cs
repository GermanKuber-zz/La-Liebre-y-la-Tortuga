using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player
{
    public class NonePlayer : IPlayer
    {
        public static NonePlayer Create => new NonePlayer();
        public int BetCardsQuantity => 0;

        public void GiveCard(IBetCard betCard)
        {

        }

        public IReadOnlyCollection<IRacingCard> RacingCards =>
        new ReadOnlyCollection<IRacingCard>(new List<IRacingCard>());

        public void TakeRacingCard()
        {
        }

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => default(ISideBoderSelected);
    }
}