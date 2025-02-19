using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;
using Web.Models.Books;
using Web.Models.Genres;

namespace Web.Controllers
{
    public class GenresController : Controller
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GenresController
        public ActionResult Index()
        {
            var genres=_context.Genres;

            return View(genres);
        }

        // GET: GenresController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return NotFound(0);

            var genre = _context.Genres.FirstOrDefault(n => n.Id == id);
            return View(genre);
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre
                {
                    Id = model.Id,
                    Name = model.Name,
                };
                _context.Genres.Add(genre);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: GenresController/Edit/5
        public ActionResult Edit(int id)
        {
            var genre = _context.Genres.FirstOrDefault(n => n.Id == id);
            if (genre == null)
            {
                return NotFound(0);
            }
            var model = new EditGenreViewModel()
            {
                Name = genre.Name
            };
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Name");
            return View(model);
        }

        // POST: GenresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditGenreViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var genre = _context.Genres.Find(id);

                genre.Name = model.Name;

                _context.Genres.Update(genre);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: GenresController/Delete/5
        public ActionResult Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(n => n.Id == id);
            if (genre == null) return NotFound();

            var model = new DeleteViewGenreModel
            {
                Id = genre.Id,
                Name = genre.Name,
            };

            return View(model);
        }

        // POST: GenresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DeleteViewGenreModel model)
        {
            var genre = _context.Genres.Find(id);

            if (genre == null) return NotFound();

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
