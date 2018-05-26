using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Tracks.Chain.DecideSide;
using Xunit;

namespace TurtleGame.Domain.Tests.Tracks.Chain.DecideSide
{
    public class DecideMaxCountDownSideChainShould
    {
        private readonly DecideMaxCountDownSideChain _sut;

        public DecideMaxCountDownSideChainShould()
        {
            _sut = new DecideMaxCountDownSideChain();
        }
        [Fact]
        private void Return_Down_If_The_Max_Count_Is_Down()
        {
            var maxDown = new ReadOnlyCollection<SideOfTrackEnum>(new List<SideOfTrackEnum>()
            {
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.UpSide,
                SideOfTrackEnum.UpSide,
            });

            var decision = _sut.Decide(maxDown);
            decision.Should().BeOfType<SideOfTrackDown>();
        }

        [Fact]
        private void Call_Next_If_There_are_others_values()
        {
            var maxDown = new ReadOnlyCollection<SideOfTrackEnum>(new List<SideOfTrackEnum>()
            {
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.UpSide,
                SideOfTrackEnum.UpSide
            });
            var mockSuccesor = new Mock<DecideSideChain>();

            _sut.SetSuccessor(mockSuccesor.Object);
            _sut.Decide(maxDown);
            mockSuccesor.Verify(mock => mock.Decide(maxDown), Times.Once());
        }
    }
}
