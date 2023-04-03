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
				TotalPages = model.TotalPages,
				UpdatedOn = DateTime.UtcNow,
			};
			await _context.Books.AddAsync(newBook);
			await _context.SaveChangesAsync();
			return newBook.Id;
		}
		public async Task <List<BookModel>> GetAllBooks() 
		{
			var books = new List<BookModel>();
			var allbooks = await _context.Books.ToListAsync();
			if(allbooks.Any()==true) 
			{
				foreach(var book in allbooks) 
				{
					books.Add(new BookModel() 
					{
						Author = book.Author,
						Category = book.Category,
						Description = book.Description,
						Title = book.Title,
						TotalPages = book.TotalPages,
						Language = book.Language,
						Id = book.Id,
					});
				}
			}
			return _books();
		}
		public BookModel GetBookById(int id) 
		{
			return _books().Where(x => x.Id == id).FirstOrDefault();
		}
		public List<BookModel> SearchBook(string title,string AuthorName) 
		{
			return _books().Where(x=>x.Title.Contains(AuthorName) && x.Title.Contains(title)).ToList();
		}
		private List<BookModel> _books() 
		{
			return new List<BookModel>()
			{
				new BookModel() {Id=1,Author="Deep",Title="C",Description="This is C Language Book Written by Deep Mavawala",Category="Coding",Language="English",TotalPages=345},
				new BookModel() {Id=2,Author="Dhruv",Title="C++",Description="This is C++ Language Book Written by Dhruv Shah",Category="Coding",Language="English",TotalPages=568},
				new BookModel() {Id=3,Author="Harsh",Title="Java",Description="This is Java Language Book Written by Harsh Shah",Category="Coding",Language="English",TotalPages=857},
				new BookModel() {Id=4,Author="Deep",Title="C#",Description="This is C# Language Book Written by Deep Mavawala",Category="Coding",Language="English",TotalPages=614},
				new BookModel() {Id=5,Author="Meet",Title="SQL",Description="This is SQL Language Book written by Meet Tanna",Category="Coding",Language="English",TotalPages=356},
                new BookModel() {Id=6,Author="Jeet",Title=".NET",Description="This is .NET Language Book written by Jeet Mehta",Category="Coding",Language="English",TotalPages=356}
            };
		}

	}
}
