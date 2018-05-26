using System;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Factories.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer Create(Func<ITrack, ISideBoderSelected> choseSideOfTrack);
    }
}