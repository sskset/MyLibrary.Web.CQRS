using Infrastructure.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public interface IBookRepository : IRepository
    {
        IEnumerable<BookDto> GetWhatsHotBooks();

        void Store(BookDto newBook);
    }
}
