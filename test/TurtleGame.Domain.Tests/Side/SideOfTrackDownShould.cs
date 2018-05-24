using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TurtleGame.Domain.Tests.Side
{
    public class SideOfTrackDownShould
    {
        private SideOfTrackDown _sut;

        public SideOfTrackDownShould()
        {
            _sut = new SideOfTrackDown();
        }

        [Fact]
        private void Have_Enum_In_Down_Value()
        {
            _sut.SideType.Should().Be(SideOfTrackEnum.DownSide);
        }
    }

    
}
