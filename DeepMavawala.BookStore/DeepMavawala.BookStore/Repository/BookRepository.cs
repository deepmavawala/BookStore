using DeepMavawala.BookStore.Models;

namespace DeepMavawala.BookStore.Repository
{
	public class BookRepository
	{
		public List<BookModel> GetAllBooks() 
		{
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
				new BookModel() {Id=1,Author="Deep",Title="C",Description="This is C Language Book Written by Deep Mavawala"},
				new BookModel() {Id=2,Author="Dhruv",Title="C++",Description="This is C++ Language Book Written by Dhruv Shah"},
				new BookModel() {Id=3,Author="Harsh",Title="Java",Description="This is Java Language Book Written by Harsh Shah"},
				new BookModel() {Id=4,Author="Deep",Title="C#",Description="This is C# Language Book Written by Deep Mavawala"},
				new BookModel() {Id=5,Author="Meet",Title="SQL",Description="This is SQL Language Book written by Meet Tanna"}
			};
		}

	}
}
