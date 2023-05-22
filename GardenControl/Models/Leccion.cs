using GardenControl.Models;
using System.ComponentModel.DataAnnotations;

namespace GardenControl2.Models
{
	public class Leccion
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "El orden es obligatorio")]
		public int Orden { get; set; }
		[Required(ErrorMessage = "La fecha es obligatasdasdasdoria")]
		public DateOnly FechaCreacion { get; set; }
		public bool Activo { get; set; }
		[Required(ErrorMessage = "La unidad es obligatoria")]
		public int UnidadId { get; set; }
		public Unidad Unidad { get; set; }
		public ICollection<Recurso> Recursos { get; set; }
	}
}
