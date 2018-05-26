using System;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(Func<ITrack, ISideBoderSelected> choseSideOfTrack);
    }
}