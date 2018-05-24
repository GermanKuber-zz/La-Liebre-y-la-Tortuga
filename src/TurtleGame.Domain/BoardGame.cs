using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Factories.Interfaces;

namespace TurtleGame.Domain
{
    public class BoardGame
    {
        public IPlayersManager Players { get; private set; }


        private readonly IList<IBetCard> _beatsCards;

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
            if (Players.NumberOfPlayers == 2)
            {
                Players.PlayerOne.GiveCard(_beatsCards[0]);
                Players.PlayerTwo.GiveCard(_beatsCards[1]);
                Players.PlayerOne.GiveCard(_beatsCards[2]);
                Players.PlayerTwo.GiveCard(_beatsCards[3]);
            }
            else
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
        }
        public IReadOnlyCollection<IBetCard> GiveAllBetCards() => new ReadOnlyCollection<IBetCard>(_beatsCards);


    }
}