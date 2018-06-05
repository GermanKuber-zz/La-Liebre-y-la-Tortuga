using System.Linq;

namespace TurtleGame.Domain.RacingCards
{

    public abstract class PreConditionRaicingCards : IPreConditionRaicingCards
    {

        private IPreConditionRaicingCards _next;

        public PreConditionRaicingCards(IPreConditionRaicingCards nextCondition)
        {
            SetNext(nextCondition);
        }
        public PreConditionRaicingCards()
        {

        }
        public void SetNext(IPreConditionRaicingCards next)
        {
            _next = next;
        }
        public virtual bool Validate(IRacingCards racingCards)
        {
            if (_next != null)
                return _next.Validate(racingCards);
            return true;
        }
    }
}