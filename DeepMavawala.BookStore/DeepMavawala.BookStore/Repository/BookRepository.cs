using DeepMavawala.BookStore.Data;
using DeepMavawala.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepMavawala.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Title = book.Title,
                      TotalPages = book.TotalPages
                  }).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(x => new BookModel() 
                {
                    Author = x.Author,
                    Category = x.Category,
                    Description = x.Description,
                    Title = x.Title,
                    TotalPages = x.TotalPages,
                    LanguageId = x.LanguageId,
                    Id = x.Id,
                    Language = x.Language.Name

                }).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBook(string title, string AuthorName)
        {
            return null;
        }
        

    }
}