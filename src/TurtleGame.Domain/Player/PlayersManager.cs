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
}