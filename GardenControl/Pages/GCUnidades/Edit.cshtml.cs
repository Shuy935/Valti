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

namespace GardenControl.Pages.GCUnidades
{
    public class EditModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public EditModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Unidad Unidad { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad =  await _context.Unidades.FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }
            Unidad = unidad;
           ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nombre");
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

            _context.Attach(Unidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadExists(Unidad.Id))
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

        private bool UnidadExists(int id)
        {
          return _context.Unidades.Any(e => e.Id == id);
        }
    }
}
