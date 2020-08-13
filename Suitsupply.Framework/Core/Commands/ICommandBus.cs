namespace Suitsupply.Framework.Core.Commands
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
       
    }
}
