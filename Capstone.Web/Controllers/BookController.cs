﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class BookController : Controller
    {
        private IBooksDAL booksDAL;

        public BookController(IBooksDAL booksDAL)
        {
            this.booksDAL = booksDAL;
        }

        //GET: Book Search
        public List<SelectListItem> searchCriteria = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Title" },
            new SelectListItem() {Text = "Author" },
            new SelectListItem() {Text = "Setting" },
            new SelectListItem() {Text = "Character" },
            //new SelectListItem() {Text = "Keyword" }

        };

        // GET: Book
        public ActionResult SearchResults(SearchResultModel model)
        {
            var value = model.SearchValue;
            var type = model.SearchType;
            model.Results = booksDAL.GetBooks(value, type);
            ViewBag.SearchCriteria = searchCriteria;
            return View("SearchResults", model);
        }

        //GET: Detail of chosen book
        public ActionResult BookDetail(int bookID)
        {
            BookModel book = new BookModel();
            book = booksDAL.GetBooksById(bookID);
            return View("BookDetail", book);
        }
        //POST: Add New Book
        [HttpPost]
        public ActionResult AddNewBook(BookModel newBook)
        {
            booksDAL.AddNewBook();
            return RedirectToAction("ThankYou");

        }

      
    }
}