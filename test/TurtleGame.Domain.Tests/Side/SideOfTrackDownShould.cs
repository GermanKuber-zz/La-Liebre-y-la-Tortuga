using FluentAssertions;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
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
