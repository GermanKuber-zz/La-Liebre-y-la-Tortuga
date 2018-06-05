using FluentAssertions;
using System;
using System.Linq;
using TurtleGame.Domain.Condition.Factories;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Factories;
using TurtleGame.Domain.Side;
using TurtleGame.SharedKernel.Strategies;
using Xunit;

namespace TurtleGame.Domain.Integration.Tests
{
    public class BoardGameShould
    {
        private BoardGame _sut;
        private readonly IBoardGameFactory _boardGameFactory;
        private readonly RegularPlayer _playerOne;
        private readonly RegularPlayer _playerTwo;
        private RegularPlayer _playerThree;

        public BoardGameShould()
        {
            _boardGameFactory = new BoardGameFactory(new PlayersManagerFactory(new RandomMixStrategy(),
                                                 new RacingCardsFactory()), new RacingCardOnDeskManager());
            _playerOne = CreateUser();
            _playerTwo = CreateUser();
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne, _playerTwo);
        }

        private static RegularPlayer CreateUser()
        {
            var random = new Random();
            return new RegularPlayer(UserCallbacksNotifications.Create(track => new SideBoderSelected(track,
                                                                                                        new SideOfTrackDown(),
                                                                                                        new LineBorderTrack()),
                                                                        x => x.ToList().First(),
                                                                        x => RacingCards.RacingCards.Create(x.ToList().GetRange(0, random.Next(0, 2)).ToList())),
                                    BetCardsPlayerManager.Create(),
                                    new RacingCardManager(new RacingCardsFactory(),
                                    new RandomMixStrategy()),
                                    new PreConditionRaicingCardsFactory().Create());
        }

        [Fact]
        public void Start_Game_With_Two_Players()
        {
            _sut.Start();

            _sut.Players.NumberOfPlayers.Should().Be(2);
            _playerOne.BetCardsQuantity.Should().Be(3);
            _playerTwo.MyRacingCards.Count().Should().Be(6);
            _playerOne.MyRacingCards.Count().Should().Be(6);
        }

        [Fact]
        public void Start_Game_With_Three_Players()
        {
            _playerThree = CreateUser();
            _sut = _boardGameFactory.ToThreePlayer(_playerOne, _playerTwo, _playerThree);
            _sut.Start();

            _sut.Players.NumberOfPlayers.Should().Be(3);
            _playerOne.BetCardsQuantity.Should().Be(2);
            _playerOne.MyRacingCards.Count().Should().Be(6);
            _playerTwo.MyRacingCards.Count().Should().Be(6);
            _playerThree.MyRacingCards.Count().Should().Be(6);
        }



    }
}
