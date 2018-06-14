using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TurtleGame.Domain.Events;

namespace TurtleGame.Domain.DomainEventHandlers
{
    public class CardsToRunCommandHandler : IRequestHandler<CardsToRunCommand, bool>
    {
        public Task<bool> Handle(CardsToRunCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}