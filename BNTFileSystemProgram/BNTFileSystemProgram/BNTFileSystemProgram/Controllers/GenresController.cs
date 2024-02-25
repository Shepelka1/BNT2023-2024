using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessLayer;
using DataLayer;
using ServiceLayer;

namespace BNTFileSystemProgram.Controllers
{
    public class TagsController : Controller
    {
        private readonly TagManager genreManager;

        public TagsController(TagManager genreManager)
        {
            this.genreManager = genreManager;
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return View(await genreManager.ReadAllAsync());
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await genreManager.ReadAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,Content")] Tag genre)
        {
            if (ModelState.IsValid)
            {
                await genreManager.CreateAsync(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tag genre = await genreManager.ReadAsync(id);
            if (genre == null) { return NotFound(); }
            return View(genre);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TagId,Content")] Tag genre)
        {
            if (id != genre.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await genreManager.UpdateAsync(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TagExists(genre.TagId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tag genreFromDb = await genreManager.ReadAsync(id, false, true);

            if (genreFromDb == null)
            {
                return NotFound();
            }

            return View(genreFromDb);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await genreManager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TagExists(string id)
        {
            return await genreManager.ReadAsync(id) is not null;
        }
    }
}
