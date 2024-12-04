﻿using CSharpClickerWeb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CSharpClickerWeb.UseCases.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private SignInManager<ApplicationUser> signInManager;

        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}
