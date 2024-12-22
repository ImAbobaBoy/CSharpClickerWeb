using CSharpClickerWeb.UseCases.DoRandomEvent;
using CSharpClickerWeb.UseCases.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSharpClickerWeb.Contorllers
{
    [Route("event")]
    public class RandomEventController : ControllerBase
    {
        private readonly IMediator mediator;

        public RandomEventController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("random")]
        public async Task<EventDto> DoEvent(DoRandomEventCommand command)
            => await mediator.Send(command);
    }
}
