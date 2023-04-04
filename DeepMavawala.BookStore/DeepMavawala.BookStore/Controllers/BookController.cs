using DeepMavawala.BookStore.Models;
using DeepMavawala.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Text;

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
			var data = await _bookRepository.GetAllBooks();
			return View(data);
		}
		public async Task<ViewResult> GetBook(int id)
		{
			var data = await _bookRepository.GetBookById(id);
			return View(data);
		}
		public List<BookModel> SearchBook(string bookname, string authorname)
		{
			return _bookRepository.SearchBook(bookname, authorname);
		}
		public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
		{
            //var model = new BookModel()
            //{
            //	//Language = "2"
            //};
            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Hindi",Value="1"},
                new SelectListItem() {Text="English",Value="2"},
                new SelectListItem() {Text="Dutch",Value="3"},
                new SelectListItem() {Text="Gujarati",Value="4"},
                new SelectListItem() {Text="Punjabi",Value="5"},
            };
            ViewBag.IsSuccess = isSuccess;
			ViewBag.BookId = bookId;
			return View();
		}
        
        [HttpPost]
		public async Task<IActionResult> AddNewBook(BookModel bookModel)
		{
			if (ModelState.IsValid)
			{
				int id = await _bookRepository.AddNewBook(bookModel);
				if (id > 0)
				{
					return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
				}
			}
            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Hindi",Value="1"},
                new SelectListItem() {Text="English",Value="2"},
                new SelectListItem() {Text="Dutch",Value="3"},
                new SelectListItem() {Text="Gujarati",Value="4"},
                new SelectListItem() {Text="Punjabi",Value="5"},
            };
            return View();
		}
        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id = 1, Text = "Hindi"},
                new LanguageModel(){ Id = 2, Text = "English"},
                new LanguageModel(){ Id = 3, Text = "Dutch"},
            };
        }
    }
}
