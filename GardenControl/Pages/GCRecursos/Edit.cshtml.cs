using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCRecursos
{
    public class EditModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public EditModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recurso Recurso { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recursos == null)
            {
                return NotFound();
            }

            var recurso =  await _context.Recursos.FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }
            Recurso = recurso;
           ViewData["LeccionId"] = new SelectList(_context.Lecciones, "Id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(Recurso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecursoExists(int id)
        {
          return _context.Recursos.Any(e => e.Id == id);
        }
    }
}
