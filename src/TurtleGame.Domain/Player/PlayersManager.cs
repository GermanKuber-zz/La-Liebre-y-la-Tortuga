using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies;

namespace TurtleGame.Domain.Player
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

        public void GiveCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            if (beatsCards == null || beatsCards.Count != 5)
                throw new ArgumentException(nameof(beatsCards));

            var beatsCardsLocal = beatsCards.ToList();
            var randomMix = new RandomMixStrategy();
            var mixValues = randomMix.Mix(EnumerableGenerator.Generate(5, x => x, 0)).ToList();

            if (NumberOfPlayers == 2)
            {
                PlayerOne.GiveCard(beatsCardsLocal[mixValues[0]]);
                PlayerTwo.GiveCard(beatsCardsLocal[mixValues[1]]);
                PlayerOne.GiveCard(beatsCardsLocal[mixValues[2]]);
                PlayerTwo.GiveCard(beatsCardsLocal[mixValues[3]]);
            }
            else
            {
                if (NumberOfPlayers >= 2)
                {
                    PlayerOne.GiveCard(beatsCardsLocal[mixValues[0]]);
                    PlayerTwo.GiveCard(beatsCardsLocal[mixValues[1]]);
                }
                if (NumberOfPlayers >= 3)
                    PlayerThree.GiveCard(beatsCardsLocal[mixValues[2]]);
                if (NumberOfPlayers >= 4)
                    PlayerFour.GiveCard(beatsCardsLocal[mixValues[3]]);
                if (NumberOfPlayers >= 5)
                    PlayerFive.GiveCard(beatsCardsLocal[mixValues[4]]);
            }
        }
    }
}