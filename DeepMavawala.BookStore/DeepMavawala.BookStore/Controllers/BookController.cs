using DeepMavawala.BookStore.Models;
using DeepMavawala.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeepMavawala.BookStore.Controllers
{
	public class BookController : Controller
	{
		private readonly BookRepository _bookRepository = null;
		public BookController(BookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}
		public async Task<ViewResult> GetAllBooks()
		{
			var data =await _bookRepository.GetAllBooks();
			return View(data);
		}
		public async Task<ViewResult> GetBook(int id)
		{
			var data= await _bookRepository.GetBookById(id);
			return View(data);
		}
		public List<BookModel> SearchBook(string bookname,string authorname)
		{
			return _bookRepository.SearchBook(bookname,authorname);
		}
		public ViewResult AddNewBook(bool isSuccess = false,int bookId =0) 
		{
			//var model = new BookModel() 
			//{
			//	Language="English"
			//};
			ViewBag.Language = new List<string>() {"Hindi","English","Dutch"};
			ViewBag.IsSuccess = isSuccess;
			ViewBag.BookId = bookId;
			return View(); 
		}
		[HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
			if(ModelState.IsValid)
			{
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new List<string>() { "Hindi", "English", "Dutch" };
            ModelState.AddModelError("", "This is my custom error message");
            return View();
        }
    }
}
