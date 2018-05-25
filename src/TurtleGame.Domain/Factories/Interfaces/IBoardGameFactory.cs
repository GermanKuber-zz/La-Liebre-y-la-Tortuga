using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Factories.Interfaces
{
    public interface IBoardGameFactory
    {
        BoardGame ToFivePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive);
        BoardGame ToFourPlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour);
        BoardGame ToThreePlayer(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour);
        BoardGame ToTwoPlayer(IPlayer playerOne, IPlayer playerTwo);
    }
}