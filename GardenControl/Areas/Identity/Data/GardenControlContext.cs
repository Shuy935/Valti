	using GardenControl.Areas.Identity.Data;
using GardenControl.Models;
using GardenControl2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace GardenControl.Data;

public class GardenControlContext : IdentityDbContext<GardenControlUser>
{
    public GardenControlContext(DbContextOptions<GardenControlContext> options)
        : base(options)
    {
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Curso>()
		.HasMany(c => c.Unidades)
		.WithOne(u => u.Curso)
		.HasForeignKey(u => u.CursoId);
		modelBuilder.Entity<Unidad>()
		.HasMany(u => u.Lecciones)
		.WithOne(l => l.Unidad)
		.HasForeignKey(l => l.UnidadId);
		modelBuilder.Entity<Leccion>()
		.HasMany(l => l.Recursos)
		.WithOne(r => r.Leccion)
		.HasForeignKey(r => r.LeccionId);

	}
	public DbSet<Curso> Cursos { get; set; }
	public DbSet<Unidad> Unidades { get; set; }
	public DbSet<Leccion> Lecciones { get; set; }
	public DbSet<Recurso> Recursos { get; set; }
}
