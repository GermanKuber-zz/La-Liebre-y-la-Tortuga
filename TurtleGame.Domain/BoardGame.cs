using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Factories.Interfaces;

namespace TurtleGame.Domain
{
    public class PlayersManager : IPlayersManager
    {
        public IPlayer PlayerFive { get; }
        public IPlayer PlayerFour { get; }
        public IPlayer PlayerThree { get; }
        public IPlayer PlayerOne { get; }
        public IPlayer PlayerTwo { get; }
        public int NumberOfPlayers { get; private set; }

        public PlayersManager(IPlayer playerOne, IPlayer playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            NumberOfPlayers = 2;
        }
        public PlayersManager(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree) : this(playerOne, playerTwo)
        {
            PlayerThree = playerThree;
            NumberOfPlayers = 3;
        }
        public PlayersManager(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour) : this(playerOne, playerTwo, playerThree)
        {
            PlayerFour = playerFour;
            NumberOfPlayers = 4;
        }
        public PlayersManager(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive) : this(playerOne, playerTwo, playerThree, playerFour)
        {
            PlayerFive = playerFive;
            NumberOfPlayers = 5;
        }
    }

    public class BoardGame
    {

        private readonly IList<IBetCard> _beatsCards;
        public IPlayersManager Players { get; private set; }

        #region Constructors

        public BoardGame(IPlayersManagerFactory playersManagerFactory)
        {
            _beatsCards = new List<IBetCard> { new Fox(), new Hare(), new Lamb(), new Turtle(), new Wolf() };
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayersManagerFactory playersManagerFactory)
            : this(playersManagerFactory)
        {
            Players = playersManagerFactory.ToTwoPlayer(playerOne, playerTwo);
        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayersManagerFactory playersManagerFactory)
            : this(playersManagerFactory)
        {
            Players = playersManagerFactory.ToThreePlayer(playerOne, playerTwo, playerThree);

        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayersManagerFactory playersManagerFactory)
            : this(playersManagerFactory)
        {
            Players = playersManagerFactory.ToFourPlayer(playerOne, playerTwo, playerThree, playerFour);

        }
        public BoardGame(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive, IPlayersManagerFactory playersManagerFactory)
            : this(playersManagerFactory)
        {
            Players = playersManagerFactory.ToFivePlayer(playerOne, playerTwo, playerThree, playerFour, playerFive);
        }

        #endregion


        public void Start()
        {
            if (Players.NumberOfPlayers >= 2)
            {
                Players.PlayerOne.GiveCard(_beatsCards[0]);
                Players.PlayerTwo.GiveCard(_beatsCards[1]);
            }
            if (Players.NumberOfPlayers >= 3)
                Players.PlayerThree.GiveCard(_beatsCards[2]);
            if (Players.NumberOfPlayers >= 4)
                Players.PlayerFour.GiveCard(_beatsCards[3]);
            if (Players.NumberOfPlayers >= 5)
                Players.PlayerFive.GiveCard(_beatsCards[4]);
        }
        public IReadOnlyCollection<IBetCard> GiveAllBetCards() => new ReadOnlyCollection<IBetCard>(_beatsCards);


    }
}