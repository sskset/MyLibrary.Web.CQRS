using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<BookDto> _inMemoryBookStore = new List<BookDto>(
            new[]
            {
                new BookDto(){ Id = Guid.NewGuid(), Title = "Do Not Open This Book", ISBN="9781760451486", Description ="From TV and radio personality Andy Lee! DO NOT OPEN THIS BOOK! This fun story will delight children and adults alike. Keep turning the pages and find out what happens when you reach the end, if you dare!" },
                new BookDto(){ Id = Guid.NewGuid(), Title = "Wild Island", ISBN = "9781760113834", Description = "Captain Charles O'Hara Booth, Commandant of Port Arthur Penal Settlement in Van Diemen's Land, fears his life will change when Sir John Franklin arrives to replace Colonel Arthur as Governor. As Franklin and his wife Jane discover, the colony is run by a clique of Arthur's former army officers, who have no intention of relinquishing power to a naval 'hero' reputed to be a simpleton. Clashes begin, observed by Harriet Adair, who has come to the island with Mrs Anna Rochester, a woman partially recovered from years living as a madwoman in the attic of Thornfield Hall. They are searching for the truth about her past in the West Indies... This astonishing and historically accurate novel intriguingly and brilliantly links Sir John Franklin's great tale of exploration and empire with Jane Eyre's iconic love story, questioning the relationship between history and fiction. It also considers the human cost of colonisation, and shows how these events lead inexorably to Franklin's last fatal expedition." }
            });


        public IEnumerable<BookDto> GetWhatsHotBooks()
        {
            return _inMemoryBookStore;
        }

        public void Store(BookDto newBook)
        {
            _inMemoryBookStore.Add(newBook);
        }
    }
}
