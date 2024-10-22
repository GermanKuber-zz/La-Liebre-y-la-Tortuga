﻿using TurtleGame.Domain.Condition.SelectedCardOfPlayers;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.Factories
{
    public interface IPreConditionRaicingCardsFactory
    {
        IPreConditionRaicingCards Create();
    }
}