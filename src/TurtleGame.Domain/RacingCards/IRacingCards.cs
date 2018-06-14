using System.Collections.Generic;
using TurtleGame.Domain.Animals;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCards : ICollectionsBase<IRacingCard>
    {
        bool AllCardAreTheSameAnimal();
        
    }
}