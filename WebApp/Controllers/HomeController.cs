using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _db;

        public HomeController(ILogger<HomeController> logger, DBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IList<KanbanCard> results = _db.KanbanCards.Select(c => c).ToList();
            KanbanBoard board = new() {
                Backlog = results.Where(c => c.ID == 0),
                InProgress = results.Where(c => c.ID == 1),
                Review = results.Where(c => c.ID == 2),
                Testing = results.Where(c => c.ID == 3),
                Done = results.Where(c => c.ID == 4),
            };

            return View(board);
        }

        public IActionResult Add(string title, string details) {

            if (title == null || details == null) return View(nameof(Index));

            _db.KanbanCards.Add(new() {
                Title = title,
                Column = 0,
                Details = details,
            });
            _db.SaveChanges();

            return View(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _db.KanbanCards.Remove(_db.KanbanCards.Find(id));
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return View(nameof(Index));
        }

        public IActionResult Move(int? id, bool forward) {
            if (id == null) return View(nameof(Index));
            KanbanCard selected = _db.KanbanCards.Find(id);

            if (forward && selected.Column + 1 < 5) selected.Column++;
            else if (!forward && selected.Column - 1 >= 0) selected.Column--;

            _db.SaveChanges();
            return View(nameof(Index));
        }

        public IActionResult Edit(int? id, string desc) {
            if (id  == null) return View(nameof(Index));
            KanbanCard selected = _db.KanbanCards.Find(id);

            if (desc != null) {
                selected.Details = desc;
            }

            _db.SaveChanges();

            return View(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
