using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CommandBase
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
