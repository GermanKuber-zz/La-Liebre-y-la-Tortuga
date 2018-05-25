namespace TurtleGame.Domain.Interfaces
{
    public interface IValueObject
    {
        bool Equals(object obj);
        int GetHashCode();
    }
}