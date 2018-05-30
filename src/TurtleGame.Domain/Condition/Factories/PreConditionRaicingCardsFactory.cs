using System;
using System.Collections.Generic;
using System.Text;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.Factories
{
    public class PreConditionRaicingCardsFactory : IPreConditionRaicingCardsFactory
    {
        public IPreConditionRaicingCards Create() => new PreConditionNoMoreThanFour();
    }
}
