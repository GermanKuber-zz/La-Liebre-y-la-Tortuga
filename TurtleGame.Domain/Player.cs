using System;

namespace TurtleGame.Domain
{
    public class Player : IPlayer
    {
        private readonly Action<IBetCard> _betCardAssignationCallBack;

        public Player(Action<IBetCard> betCardAssignationCallBack)
        {
            _betCardAssignationCallBack = betCardAssignationCallBack ?? throw new ArgumentException(nameof(betCardAssignationCallBack));
        }

        public void GiveCard(IBetCard betCard) => _betCardAssignationCallBack(betCard);
    }
}