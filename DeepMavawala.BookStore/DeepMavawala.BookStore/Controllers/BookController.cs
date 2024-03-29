﻿using DeepMavawala.BookStore.Models;
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
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        [HttpGet]
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();
            ViewBag.language = new SelectList( await _languageRepository.GetLanguages(),"Id","Name");
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
            ViewBag.language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }
    }
}