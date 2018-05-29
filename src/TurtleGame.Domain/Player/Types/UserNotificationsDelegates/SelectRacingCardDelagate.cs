using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.Types.UserNotificationsDelegates
{
    public delegate IReadOnlyCollection<IRacingCard> SelectRacingCardDelagate(IReadOnlyCollection<IRacingCard> track);
}