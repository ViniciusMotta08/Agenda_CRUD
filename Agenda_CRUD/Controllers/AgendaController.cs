using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaCRUD.Models;
using Agenda_CRUD.Models;

namespace Agenda_CRUD.Controllers
{
    public class AgendaController : Controller
    {
        private readonly AgendaContext _context;

        public AgendaController(AgendaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Agenda != null ?
                        View(await _context.Agenda.ToListAsync()) :
                        Problem("Entity set 'AgendaContext.Agenda'  is null.");
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Agenda());
            else
                return View(_context.Agenda.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FullName,Telephone,Email")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                if (agenda.Id == 0)
                    _context.Add(agenda);
                else
                    _context.Update(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var agenda = await _context.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
