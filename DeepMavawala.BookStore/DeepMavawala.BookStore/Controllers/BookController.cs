﻿using DeepMavawala.BookStore.Models;
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
		public ViewResult GetBook(int id)
		{
			var data= _bookRepository.GetBookById(id);
			return View(data);
		}
		public List<BookModel> SearchBook(string bookname,string authorname)
		{
			return _bookRepository.SearchBook(bookname,authorname);
		}
		public ViewResult AddNewBook(bool isSuccess = false,int bookId =0) 
		{
			ViewBag.IsSuccess = isSuccess;
			ViewBag.BookId = bookId;
			return View(); 
		}
		[HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
			int id= await _bookRepository.AddNewBook(bookModel);
			if(id>0) 
			{
				return RedirectToAction(nameof(AddNewBook), new {isSuccess = true, bookId = id});
			}
            return View();
        }
    }
}
