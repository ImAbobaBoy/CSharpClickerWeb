using MediatR;

namespace CSharpClickerWeb.UseCases.SetUserAvatar;

public record SetUserAvatarCommand(IFormFile Avatar) : IRequest<Unit>;