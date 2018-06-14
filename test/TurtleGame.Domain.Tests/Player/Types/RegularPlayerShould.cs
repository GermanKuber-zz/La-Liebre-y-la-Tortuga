using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Condition.SelectedCardOfPlayers;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.Domain.Tracks.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Types
{
    public class RegularPlayerShould
    {
        private IPlayer _sut;
        private Domain.RacingCards.RacingCards _listOfSelectRacing;
        private readonly List<IRacingCard> _listOfRaicingCards = new List<IRacingCard>
        {
            new Mock<IRacingCard>().Object,
            new Mock<IRacingCard>().Object,
            new Mock<IRacingCard>().Object
        };

        private readonly Mock<IBetCardsPlayerManager> _mockBetCardsPlayerManager =
            new Mock<IBetCardsPlayerManager> { DefaultValue = DefaultValue.Mock };

        private readonly Mock<IUserCallbacksNotifications> _mockUserCallbacksNotifications =
            new Mock<IUserCallbacksNotifications> { DefaultValue = DefaultValue.Mock };

        private readonly Mock<IRacingCardManager> _mockRacingCardManager =
            new Mock<IRacingCardManager> { DefaultValue = DefaultValue.Mock };

        private Mock<IPreConditionRaicingCards> _mockPreConditionRaicingCards =
            new Mock<IPreConditionRaicingCards> { DefaultValue = DefaultValue.Mock };

        public RegularPlayerShould()
        {
            _mockRacingCardManager.SetupSequence(x => x.TakeCard())
                .Returns(_listOfRaicingCards[0])
                .Returns(_listOfRaicingCards[1])
                .Returns(_listOfRaicingCards[2]);
            _listOfSelectRacing = Domain.RacingCards.RacingCards.Create(_listOfRaicingCards.Take(2).ToList());

            _mockUserCallbacksNotifications
                .Setup(x => x.SelectRacingCard)
                .Returns(x => _listOfSelectRacing);
            _mockUserCallbacksNotifications.Setup(x => x.ChooseSecondBet).Returns(x => _listOfRaicingCards.First());

            _mockPreConditionRaicingCards.Setup(x => x.Validate(It.IsAny<IRacingCards>())).Returns(true);
            CreateRularPlayer();
            _sut.TakeRacingCard();
            _sut.TakeRacingCard();
        }

        [Fact]
        public void Not_Accept_Null_In_Parameters()
        {
            Action call = () => _sut = new RegularPlayer(null
                , _mockBetCardsPlayerManager.Object
                , _mockRacingCardManager.Object,
                _mockPreConditionRaicingCards.Object);

            call.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Notify_When_Receive_Track_To_Chose_Side()
        {
            _sut.ChooseSideOfTrack(new Mock<ITrack>().Object);
            _mockUserCallbacksNotifications.Verify(x => x.ChooseSideOfTrack, Times.Once);
        }


        [Fact]
        public void Add_Racing_Card_To_List_Of_Racings_Cards()
        {
            _sut.TakeRacingCard();
            _sut.MyRacingCards.Count().Should().Be(3);
        }

        [Fact]
        public void Call_Function_To_Player_Select_Cards()
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
            _sut.CardsTurn(callback.Object);

            callback.Verify(x => x(It.IsAny<IRacingCards>()), Times.Once);
        }

        [Fact]
        public void Call_Pre_Conditions_Validations_Two_Times()
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
            _mockPreConditionRaicingCards.SetupSequence(x => x.Validate(It.IsAny<IRacingCards>()))
                                                        .Returns(false)
                                                        .Returns(true);
            _sut.CardsTurn(callback.Object);

            _mockPreConditionRaicingCards.Verify(x => x.Validate(It.IsAny<IRacingCards>()), Times.Exactly(2));
        }

        [Fact]
        public void Call_Pre_Conditions_Validations_One_Times()
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
      
            _sut.CardsTurn(callback.Object);

            _mockPreConditionRaicingCards.Verify(x => x.Validate(It.IsAny<IRacingCards>()), Times.Once);
        }

        //[Fact]
        //public void Take_Out_Cards_From_My_Cards()
        //{
        //    var callback = new Mock<SelectedCardsConfirmationDelegate>();
        //    callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
        //    _sut.CardsTurn(callback.Object);
        //    _mockRacingCardManager.Verify(x => x.FallCardsToDeck(It.IsAny<IRacingCards>()), Times.Once);
        //}

        [Fact]
        public void Have_The_Same_Quantity_Of_Cards_In_Hand()
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
            _sut.TakeRacingCard();
            _sut.CardsTurn(callback.Object);
            _sut.MyRacingCards.Count().Should().Be(3);
        }

        [Fact]
        public void Call_Callback_With_All_Available_Racing_Cards()
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            callback.Setup(x => x(It.IsAny<IRacingCards>())).Returns(true);
            _sut.CardsTurn(callback.Object);

            callback.Verify(x => x(_listOfSelectRacing), Times.Once);
        }

        [Fact]
        public void Call_User_CallBack_To_Select_Second_Bet()
        {
            _sut = new RegularPlayer(_mockUserCallbacksNotifications.Object,
                BetCardsPlayerManager.Create(),
                _mockRacingCardManager.Object,
                _mockPreConditionRaicingCards.Object);

            _sut.ChooseSecondBet();
            _mockUserCallbacksNotifications.Verify(x => x.ChooseSecondBet, Times.Once);
        }

        [Fact]
        public void Remove_Selected_Card_From_Raicing_Cards()
        {
            _sut.ChooseSecondBet();
            _sut.MyRacingCards.Count().Should().Be(1);
        }


        private void CreateRularPlayer()
        {
            _sut = new RegularPlayer(_mockUserCallbacksNotifications.Object
                , _mockBetCardsPlayerManager.Object
                , _mockRacingCardManager.Object,
                _mockPreConditionRaicingCards.Object);
        }
    }
}