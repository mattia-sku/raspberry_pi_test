using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebServerCloud.Data;
using WebServerCloud.Models;
using WebServerCloud.Models.ViewModels;

namespace WebServerCloud.Controllers
{
    public class OrdinesController : Controller
    {
        private readonly WebServerCloudContext _context;

        public OrdinesController(WebServerCloudContext context)
        {
            _context = context;
        }

        // GET: Ordines
        public async Task<IActionResult> Index()
        {
            return View(
                await _context.ordini
                    .Include((x) => x.AudioProtesista)
                    .OrderBy((x) => x.DataCaricamento)
                    .Select((x) => new OrdineIndex() { 
                        OrderId = x.Id, 
                        RagioneSociale = x.AudioProtesista.RagioneSociale, 
                        DataCaricamento = x.DataCaricamento 
                    }).ToListAsync()
            );
        }

        // GET: Ordines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordine = await _context.ordini
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        [HttpGet("video/{id}")]
        public IActionResult GetVideo(Guid? id)
        {
            return PhysicalFile($"awesomeVideo.mp4", "application/octet-stream", enableRangeProcessing: true);
        }

        // POST: Ordines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                ordine.Id = Guid.NewGuid();
                _context.Add(ordine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordine);
        }

        // GET: Ordines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordine = await _context.ordini
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // POST: Ordines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ordine = await _context.ordini.FindAsync(id);
            _context.ordini.Remove(ordine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdineExists(Guid id)
        {
            return _context.ordini.Any(e => e.Id == id);
        }
    }
}
