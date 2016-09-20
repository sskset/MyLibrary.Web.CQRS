using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CommandBase
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public async Task<CommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = ServiceLocator.Current.GetInstance<ICommandHandler<TCommand>>();
            return await handler.Execute(command);
        }
    }
}
