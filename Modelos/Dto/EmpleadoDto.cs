using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ws.expediente.Modelos.Dto
{
    public class EmpleadoDto
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Apellidos { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nombres { get; set; }
        //public DateTime? FechaNacimiento { get; set; }
        public int? SexoId { get; set; }
        public int? EstadoFamId { get; set; }
        public string? Direccion { get; set; }
        
    }
}
