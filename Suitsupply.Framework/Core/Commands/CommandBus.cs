using System;
using Suitsupply.Framework.Core.DependencyInjection;

namespace Suitsupply.Framework.Core.Commands
{
    public class CommandBus: ICommandBus
    {
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                // TODO Log Command
            }
            catch { }

            try
            {
                var handler = DotNetCoreServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();
                handler.Handle(command);
                handler.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    // TODO Log Exception
                }
                catch { }

                throw ex;
            }
        }


    }
}
