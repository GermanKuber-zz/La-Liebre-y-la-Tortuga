using FluentAssertions;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using Xunit;

namespace TurtleGame.Domain.Tests.Side
{
    public class SideOfTrackUpShould
    {
        private readonly SideOfTrackUp _sut;

        public SideOfTrackUpShould()
        {
            _sut = new SideOfTrackUp();
        }

        [Fact]
        private void Have_Enum_In_Down_Value()
        {
            _sut.SideType.Should().Be(SideOfTrackEnum.UpSide);
        }
    }

    
}
