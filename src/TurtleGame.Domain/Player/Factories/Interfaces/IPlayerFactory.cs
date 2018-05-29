using System;
using System.Collections.Generic;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Factories.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer Create(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard);
    }
}