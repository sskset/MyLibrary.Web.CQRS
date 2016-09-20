using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.QueryBase;
using MyLibrary.Queries;
using MyLibrary.Models;
using Infrastructure.CommandBase;
using MyLibrary.Commands;

namespace MyLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public HomeController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public ActionResult Index()
        {
            var task = _queryDispatcher.Dispatch<WhatsHotQuery, WhatsHotQueryResult>(new WhatsHotQuery());

            ViewBag.HotBooks = task.Result.Books;

            return View(ViewBag);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookDto newBook)
        {
            if (ModelState.IsValid)
            {
                _commandDispatcher.Dispatch<CreateBookCommand>(new CreateBookCommand() { NewBook = newBook });
                return RedirectToAction("Index");
            }

            return View(newBook);
        }
    }
}
