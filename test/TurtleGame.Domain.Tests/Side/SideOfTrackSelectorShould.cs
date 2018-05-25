using FluentAssertions;
using TurtleGame.Domain.Side;
using Xunit;

namespace TurtleGame.Domain.Tests.Side
{
    public class SideOfTrackSelectorShould
    {
       
        [Theory]
        [InlineData(false, true, true, true)]
        [InlineData(true, false, true, true)]
        [InlineData(true, true, false, true)]
        [InlineData(true, true, true, false)]
        public void Set_Al_Values_In_Internal_State(bool verticalDownEnable,
            bool verticalUpEnable,
            bool verticalLeftEnable,
            bool verticalRigthEnable)
        {
            var sut = new SideOfTrackSelector(verticalDownEnable, verticalUpEnable, verticalLeftEnable, verticalRigthEnable);
            sut.VerticalDownEnable.Should().Be(verticalDownEnable);
            sut.VerticalUpEnable.Should().Be(verticalUpEnable);
            sut.VerticalLeftEnable.Should().Be(verticalLeftEnable);
            sut.VerticalRigthEnable.Should().Be(verticalRigthEnable);
        }
    }
}
