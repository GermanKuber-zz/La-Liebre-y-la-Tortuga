using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Tracks.Chain.DecideSide;
using Xunit;

namespace TurtleGame.Domain.Tests.Tracks.Chain.DecideSide
{
    public class DecideMaxCountUpSideChainShould
    {
        private DecideMaxCountUpSideChain _sut;

        public DecideMaxCountUpSideChainShould()
        {
            _sut = new DecideMaxCountUpSideChain();
        }
        [Fact]
        private void Return_Up_If_The_Max_Count_Is_Up()
        {
            var maxDown = new ReadOnlyCollection<SideOfTrackEnum>(new List<SideOfTrackEnum>()
            {
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.UpSide,
                SideOfTrackEnum.UpSide,
            });

            var decision = _sut.Decide(maxDown);
            decision.Should().BeOfType<SideOfTrackUp>();
        }

        [Fact]
        private void Call_Next_If_There_are_More_than_others_values()
        {
            var maxUp = new ReadOnlyCollection<SideOfTrackEnum>(new List<SideOfTrackEnum>()
            {
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.DownSide,
                SideOfTrackEnum.UpSide
            });
            var mockSuccesor = new Mock<DecideSideChain>();

            _sut.SetSuccessor(mockSuccesor.Object);
            _sut.Decide(maxUp);
            mockSuccesor.Verify(mock => mock.Decide(maxUp), Times.Once());

        }
    }
}
