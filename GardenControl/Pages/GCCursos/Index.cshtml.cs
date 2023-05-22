using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCCursos
{
    public class IndexModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public IndexModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        public IList<Curso> Curso { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cursos != null)
            {
                Curso = await _context.Cursos.ToListAsync();
            }
        }
    }
}
