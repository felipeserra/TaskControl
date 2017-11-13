namespace TaskControl.Domain.Interfaces.Service.Core
{
    public interface IRemoveDomainService<TCommand> where TCommand : class
    {
        System.Threading.Tasks.Task Remove(TCommand command);
    }
}