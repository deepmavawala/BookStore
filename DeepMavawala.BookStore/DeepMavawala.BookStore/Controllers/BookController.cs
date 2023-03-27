﻿using DeepMavawala.BookStore.Models;
using DeepMavawala.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DeepMavawala.BookStore.Controllers
{
	public class BookController : Controller
	{
		private readonly BookRepository bookRepository = null;
		public BookController()
		{
			bookRepository= new BookRepository();
		}
		public ViewResult GetAllBooks()
		{
			var data = bookRepository.GetAllBooks();
			return View();
		}
		public BookModel GetBook(int id)
		{
			return bookRepository.GetBookById(id);
		}
		public List<BookModel> SearchBook(string bookname,string authorname)
		{
			return bookRepository.SearchBook(bookname,authorname);
		}
	}
}