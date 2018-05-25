using System;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayerManagerShould
    {
        private Domain.Player.Player _sut;
        private Mock<ISideBoderSelected> _mockSideBorderSelected = new Mock<ISideBoderSelected>();
        private Func<ITrack, ISideBoderSelected> _choseSideOfTrack;
        public PlayerManagerShould()
        {
            _choseSideOfTrack = (track) => _mockSideBorderSelected.Object;
            _sut = new Domain.Player.Player(_choseSideOfTrack);
        }
      

    }
}