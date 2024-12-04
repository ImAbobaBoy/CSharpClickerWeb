using CSharpClickerWeb.UseCases.GetLeaderboard;
using CSharpClickerWeb.UseCases.SetUserAvatar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSharpClickerWeb.Contorllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("avatar")]
        public async Task<IActionResult> SetAvatar(SetUserAvatarCommand command)
        {
            await mediator.Send(command);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("leaderboard")]
        public async Task<IActionResult> Leaderboard()
        {
            var leaderboard = await mediator.Send(new GetLeaderboardQuery());

            return View(leaderboard);
        }
    }
}
