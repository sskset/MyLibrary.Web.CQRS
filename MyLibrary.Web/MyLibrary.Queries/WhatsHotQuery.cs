using Infrastructure.QueryBase;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Queries
{
    public class WhatsHotQuery : IQuery
    {
    }

    public class WhatsHotQueryResult : IQueryResult
    {
        public IEnumerable<BookDto> Books { get; set; }
    }

    public class WhatsHotQueryHandler : IQueryHandler<WhatsHotQuery, WhatsHotQueryResult>
    {
        private readonly IBookRepository _bookRepository;

        public WhatsHotQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<WhatsHotQueryResult> Retrieve(WhatsHotQuery query)
        {
            WhatsHotQueryResult result = new WhatsHotQueryResult();
            result.Books = _bookRepository.GetWhatsHotBooks();
            return result;
        }
    }

}
