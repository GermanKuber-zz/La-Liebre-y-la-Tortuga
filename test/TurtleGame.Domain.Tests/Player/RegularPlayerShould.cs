using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Factories;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
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
        private Func<ITrack, ISideBoderSelected> _chooseSideOfTrack;
        private Func<IReadOnlyCollection<IRacingCard>, IRacingCard> _chooseSecondBetCard;
        private readonly Mock<IRacingCardManager> _mockRacingCardManager = new Mock<IRacingCardManager>();

        public RegularPlayerShould()
        {
            _chooseSideOfTrack = (track) => _mockSideBorderSelected.Object;
            _chooseSecondBetCard = cards => cards.ToList().First();
            CreateRularPlayer();
        }

        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut = new RegularPlayer(null, null, _mockRacingCardManager.Object);

            call.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Notify_When_Receive_Track_To_Chose_Side()
        {
            var mockTrack = new Mock<ITrack>();
            var call = false;
            _chooseSideOfTrack = (x) =>
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
            _chooseSideOfTrack = (x) => _mockSideBorderSelected.Object;

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

        [Fact]
        public void Call_User_CallBack_To_Select_Second_Bet()
        {
            var mockChooseSecondBet = new Mock<Func<IReadOnlyCollection<IRacingCard>, IRacingCard>>();
            _sut = new RegularPlayer(_chooseSideOfTrack, mockChooseSecondBet.Object, _mockRacingCardManager.Object);

            _sut.ChooseSecondBet();
            mockChooseSecondBet.Verify(x => x(It.IsAny<IReadOnlyCollection<IRacingCard>>()), Times.Once);
        }

        [Fact]
        public void Remove_Selected_Card_From_Raicing_Cards()
        {
            var mockChooseSecondBet = new Mock<Func<IReadOnlyCollection<IRacingCard>, IRacingCard>>();
            var returnBet = new Mock<IRacingCard>();
            _mockRacingCardManager.Setup(x => x.TakeCard()).Returns(returnBet.Object);   
            mockChooseSecondBet.Setup(x => x(It.IsAny<IReadOnlyCollection<IRacingCard>>())).Returns(returnBet.Object);
            _sut = new RegularPlayer(_chooseSideOfTrack, mockChooseSecondBet.Object, _mockRacingCardManager.Object);
            _sut.TakeRacingCard();
            _mockRacingCardManager.Setup(x => x.TakeCard()).Returns(new Mock<IRacingCard>().Object);
            _sut.TakeRacingCard();


            _sut.ChooseSecondBet();

            _sut.RacingCards.Count.Should().Be(1);
        }


        private void CreateRularPlayer()
        {
            _sut = new RegularPlayer(_chooseSideOfTrack, _chooseSecondBetCard, _mockRacingCardManager.Object);
        }
    }
}