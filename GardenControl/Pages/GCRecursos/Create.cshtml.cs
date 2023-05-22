using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCRecursos
{
    public class CreateModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public CreateModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LeccionId"] = new SelectList(_context.Lecciones, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Recurso Recurso { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recursos.Add(Recurso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
