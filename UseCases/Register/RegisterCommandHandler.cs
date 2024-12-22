using CSharpClickerWeb.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSharpClickerWeb.UseCases.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (userManager.Users.Any(u => u.UserName == request.UserName))
            {
                throw new ValidationException("Such user already exists.");
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors;
                foreach (var error in errors)
                {
                    var errorString = string.Join(Environment.NewLine, error.Description);
                    throw new ValidationException(errorString);
                }
            }

            return Unit.Value;
        }
    }
}
