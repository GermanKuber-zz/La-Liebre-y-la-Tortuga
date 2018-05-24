using System;

namespace TurtleGame.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}