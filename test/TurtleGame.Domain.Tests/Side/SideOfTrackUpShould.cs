using FluentAssertions;
using Xunit;

namespace TurtleGame.Domain.Tests.Side
{
    public class SideOfTrackUpShould
    {
        private SideOfTrackUp _sut;

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
