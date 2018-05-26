using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Factories;
using TurtleGame.Domain.Side;
using TurtleGame.SharedKernel.Strategies;
using Xunit;

namespace TurtleGame.Domain.Integration.Tests
{
    public class BoardGameShould
    {
        private readonly BoardGame _sut;

        public BoardGameShould()
        {
            IBoardGameFactory boardGameFactory = new BoardGameFactory(new PlayersManagerFactory());
            var playerOne = new RegularPlayer((track => new SideBoderSelected(track,
                new SideOfTrackDown(), new LineBorderTrack())), new RacingCardManager(new RacingCardsFactory(),
                new RandomMixStrategy()));
            var playerTwo = new RegularPlayer((track => new SideBoderSelected(track,
                new SideOfTrackDown(), new LineBorderTrack())), new RacingCardManager(new RacingCardsFactory(),
                new RandomMixStrategy()));
            _sut = boardGameFactory.ToTwoPlayer(playerOne, playerTwo);
        }

        [Fact]
        public void Start_Game_With_Two_Players()
        {
            _sut.Start();
            _sut.Players.Players.NumberOfPlayers.Should().Be(2);
            _sut.Players.Players.PlayerOne.BetCardsQuantity.Should().Be(2);
            _sut.Players.Players.PlayerTwo.RacingCards.Count.Should().Be(7);
            _sut.Players.Players.PlayerOne.RacingCards.Count.Should().Be(7);
        }
    }
}
