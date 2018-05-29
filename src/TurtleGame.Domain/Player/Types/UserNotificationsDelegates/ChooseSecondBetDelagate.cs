using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.Types.UserNotificationsDelegates
{
    public delegate IRacingCard ChooseSecondBetDelagate(IReadOnlyCollection<IRacingCard> track);
}