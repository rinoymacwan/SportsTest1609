using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsTestApp1609.Models;

namespace SportsTestApp1609.Controllers
{
    public class UserTestMappingsController : Controller
    {
        private readonly SportsTestApp1609Context _context;

        public UserTestMappingsController(SportsTestApp1609Context context)
        {
            _context = context;
        }

        // GET: UserTestMappings
        public async Task<IActionResult> Index()
        {
            var sportsTestApp1609Context = _context.UserTestMapping.Include(u => u.Test).Include(u => u.User).Where(k => k.User.Type!="Coach");
            return View(await sportsTestApp1609Context.ToListAsync());
        }

        // GET: UserTestMappings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestMapping = await _context.UserTestMapping
                .Include(u => u.Test)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTestMapping == null)
            {
                return NotFound();
            }

            return View(userTestMapping);
        }

        // GET: UserTestMappings/Create
        public IActionResult Create()
        {
            ViewData["TId"] = new SelectList(_context.Test, "Id", "Id", TempData["TId"]);
            ViewData["UId"] = new SelectList(_context.User.Where(k => k.Type != "Coach"), "Id", "Name");

            return View();
        }

        // POST: UserTestMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Distance,Time,FitnessRating,TId,UId")] UserTestMapping userTestMapping)
        {
            if (ModelState.IsValid)
            {
                if(userTestMapping.Distance<=1000)
                {
                    userTestMapping.FitnessRating = "Below Average";
                }
                else if(userTestMapping.Distance>1000 && userTestMapping.Distance<=2000)
                {
                    userTestMapping.FitnessRating = "Average";
                }
                else if (userTestMapping.Distance > 2000 && userTestMapping.Distance <= 3500)
                {
                    userTestMapping.FitnessRating = "Good";
                }
                else if (userTestMapping.Distance > 3500)
                {
                    userTestMapping.FitnessRating = "Very good";
                }
                _context.Add(userTestMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Tests", new { Id = userTestMapping.TId });
            }
            ViewData["TId"] = new SelectList(_context.Test, "Id", "Id", userTestMapping.TId);
            ViewData["UId"] = new SelectList(_context.User.Where(k => k.Type != "Coach"), "Id", "Name", userTestMapping.UId);
            TempData["dist"]= "na";
            TempData["time"]= "na";
            return View(userTestMapping);
        }

        // GET: UserTestMappings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestMapping = await _context.UserTestMapping.FindAsync(id);
            var test = await _context.Test.FindAsync(userTestMapping.TId);
            if ( test.Type== "Coopertest")
            {
                TempData["time"] = "hidden";
                TempData["dist"] = "visible";
            }
            else
            {
                TempData["time"] = "visible";
                TempData["dist"] = "hidden";
            }
            if (userTestMapping == null)
            {
                return NotFound();
            }
            ViewData["TId"] = new SelectList(_context.Test, "Id", "Id", userTestMapping.TId);
            ViewData["UId"] = new SelectList(_context.User.Where(k => k.Type != "Coach"), "Id", "Name", userTestMapping.UId);
            return View(userTestMapping);
        }

        // POST: UserTestMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distance,Time,FitnessRating,TId,UId")] UserTestMapping userTestMapping)
        {
            if (id != userTestMapping.Id)
            {
                return NotFound();
            }
            if (userTestMapping.Distance <= 1000)
            {
                userTestMapping.FitnessRating = "Below Average";
            }
            else if (userTestMapping.Distance > 1000 && userTestMapping.Distance <= 2000)
            {
                userTestMapping.FitnessRating = "Average";
            }
            else if (userTestMapping.Distance > 2000 && userTestMapping.Distance <= 3500)
            {
                userTestMapping.FitnessRating = "Good";
            }
            else if (userTestMapping.Distance > 3500)
            {
                userTestMapping.FitnessRating = "Very good";
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTestMapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTestMappingExists(userTestMapping.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Tests", new { Id = userTestMapping.TId });
            }
            ViewData["TId"] = new SelectList(_context.Test, "Id", "Id", userTestMapping.TId);
            ViewData["UId"] = new SelectList(_context.User.Where(k => k.Type != "Coach"), "Id", "Name", userTestMapping.UId);
            return View(userTestMapping);
        }

        // GET: UserTestMappings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTestMapping = await _context.UserTestMapping
                .Include(u => u.Test)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTestMapping.Test.Type == "Coopertest")
            {
                TempData["time"] = "hidden";
                TempData["dist"] = "visible";
            }
            else
            {
                TempData["time"] = "visible";
                TempData["dist"] = "hidden";
            }
            if (userTestMapping == null)
            {
                return NotFound();
            }

            return View(userTestMapping);
        }

        // POST: UserTestMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTestMapping = await _context.UserTestMapping.FindAsync(id);
            var x = userTestMapping.TId;
            _context.UserTestMapping.Remove(userTestMapping);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Tests", new { Id = x});
        }

        private bool UserTestMappingExists(int id)
        {
            return _context.UserTestMapping.Any(e => e.Id == id);
        }
    }
}
