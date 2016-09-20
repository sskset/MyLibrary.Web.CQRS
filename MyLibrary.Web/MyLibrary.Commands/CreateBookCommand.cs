using Infrastructure.CommandBase;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Commands
{
    public class CreateBookCommand : ICommand
    {
        public BookDto NewBook { get; set; }
    }

    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<CommandResult> Execute(CreateBookCommand command)
        {
            _bookRepository.Store(command.NewBook);

            return new CommandResult() { Success = true };
        }
    }
}
