using System.Linq;

namespace TurtleGame.Domain.RacingCards
{

    public abstract class PreConditionRaicingCards : IPreConditionRaicingCards
    {

        private IPreConditionRaicingCards _next;
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

    public class PreConditionNoMoreThanFour : PreConditionRaicingCards
    {

        public override bool Validate(IRacingCards racingCards)
        {
            if (racingCards.Count() > 4)
                return false;

            return base.Validate(racingCards);
        }
    }
}