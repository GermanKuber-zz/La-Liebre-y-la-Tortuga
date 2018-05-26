using System;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Factories;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class RegularPlayerShould
    {
        private IPlayer _sut;
        private readonly Mock<ISideBoderSelected> _mockSideBorderSelected = new Mock<ISideBoderSelected>();
        private Func<ITrack, ISideBoderSelected> _choseSideOfTrack;
        private readonly Mock<IRacingCardManager> _mockRacingCardManager = new Mock<IRacingCardManager>();

        public RegularPlayerShould()
        {
            new PlayerFactory(_mockRacingCardManager.Object);
            _choseSideOfTrack = (track) => _mockSideBorderSelected.Object;
            CreateRularPlayer();
        }

        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut = new RegularPlayer(null, _mockRacingCardManager.Object);

            call.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Notify_When_Receive_Track_To_Chose_Side()
        {
            var mockTrack = new Mock<ITrack>();
            var call = false;
            _choseSideOfTrack = (x) =>
            {
                call = true;
                return _mockSideBorderSelected.Object;
            };
            CreateRularPlayer();

            _sut.ChooseSideOfTrack(mockTrack.Object);
            call.Should().Be(true);
        }

        [Theory]
        [InlineData(SideOfTrackEnum.DownSide)]
        [InlineData(SideOfTrackEnum.UpSide)]
        public void Notify_Return_Same_Value_That_I_Returned(SideOfTrackEnum sideChoosed)
        {
            var mockTrack = new Mock<ITrack>();
            _choseSideOfTrack = (x) => _mockSideBorderSelected.Object;

            _mockSideBorderSelected.Setup(x => x.SideOfTrack.SideType).Returns(sideChoosed);

            CreateRularPlayer();
            _sut.ChooseSideOfTrack(mockTrack.Object).SideOfTrack.SideType.Should().Be(sideChoosed);
        }
        [Fact]
        public void Accept_One_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(1);
        }
        [Fact]
        public void Accept_Two_Bet_Card()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            _sut.BetCardsQuantity.Should().Be(2);
        }
        [Fact]
        public void Produced_Error_Doest_Not_Accept_More_Than_Two_BetCards()
        {
            _sut.GiveCard(new Mock<IBetCard>().Object);
            _sut.GiveCard(new Mock<IBetCard>().Object);

            Action act = () => _sut.GiveCard(new Mock<IBetCard>().Object);

            act.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Add_Racing_Card_To_List_Of_Racings_Cards()
        {
            _sut.TakeRacingCard();

            _sut.RacingCards.Count.Should().Be(1);
        }
        private void CreateRularPlayer()
        {
            _sut = new RegularPlayer(_choseSideOfTrack, _mockRacingCardManager.Object);
        }
    }
}