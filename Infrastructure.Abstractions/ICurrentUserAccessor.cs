namespace CSharpClickerWeb.Infrastructure.Abstractions
{
    public interface ICurrentUserAccessor
    {
        Guid GetCurrentUserId();
    }
}
