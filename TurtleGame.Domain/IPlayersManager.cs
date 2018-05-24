namespace TurtleGame.Domain
{
    public interface IPlayersManager
    {
        int NumberOfPlayers { get; }
         IPlayer PlayerFive { get; }
         IPlayer PlayerFour { get; }
         IPlayer PlayerThree { get; }
         IPlayer PlayerOne { get; }
         IPlayer PlayerTwo { get; }
    }
}