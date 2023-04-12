namespace Briefcase.Handlers.Handleds.Interfaces
{
    public interface IHandledChange : IHandled
    {
        object LastValue { get; }
    }
}
