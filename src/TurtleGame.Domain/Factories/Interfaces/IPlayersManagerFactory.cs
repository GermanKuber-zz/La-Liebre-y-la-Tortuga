using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Factories.Interfaces
{
    public interface IPlayersManagerFactory
    {
        IPlayersManager ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive);
        IPlayersManager ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour);
        IPlayersManager ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree);
        IPlayersManager ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo);
    }
}