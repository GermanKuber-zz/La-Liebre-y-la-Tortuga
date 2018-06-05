using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Condition.Factories;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Factories;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.SharedKernel.Strategies;
using Xunit;

namespace TurtleGame.Domain.Integration.Tests
{
    public class BoardGameShould
    {
        private BoardGame _sut;
        private readonly IRacingCardManager _racingCardManager;
        private readonly IBoardGameFactory _boardGameFactory;
        private readonly RegularPlayer _playerOne;
        private readonly RegularPlayer _playerTwo;
        private RegularPlayer _playerThree;
        private IRacingCardsFactory _racingCardsFactory = new RacingCardsFactory();
        private IRacingCardOnDeskManager _racingCardOnDeskManager = new RacingCardOnDeskManager();
        public BoardGameShould()
        {
            _racingCardManager = new RacingCardManager(_racingCardsFactory,
                                                          new RandomMixStrategy(),
                                                          _racingCardOnDeskManager);
            _boardGameFactory = new BoardGameFactory(new PlayersManagerFactory(new RandomMixStrategy(),
                                                                               new RacingCardsFactory(),
                                                                               _racingCardOnDeskManager),
                                                     _racingCardOnDeskManager);
            _playerOne = CreateUser();
            _playerTwo = CreateUser();
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne, _playerTwo);
        }

        private RegularPlayer CreateUser()
        {
            var random = new Random();
            return new RegularPlayer(UserCallbacksNotifications.Create(track => new SideBoderSelected(track,
                                                                                                        new SideOfTrackDown(),
                                                                                                        new LineBorderTrack()),
                                                                        x => x.ToList().First(),
                                                                        x => RacingCards.RacingCards.Create(new List<IRacingCard> { x.ToList().First() })),
                                    BetCardsPlayerManager.Create(),
                                   _racingCardManager,
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
