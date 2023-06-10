using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ws.expediente.Modelos
{
    public partial class Empleado
    {
        internal int? sexoId;

        [Key]
        //Genera un auto incremento en id int
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? SexoId { get; set; }
        public int? EstadoFamId { get; set; }
        public string? Direccion { get; set; }
        public int? DepId { get; set; }
        public int? MunId { get; set; }
        public string? TelefonoCasa { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? CelularInstitucional { get; set; }
        public string? FijoInstitucional { get; set; }
        public string? Faxinstitucional { get; set; }
        public string? ExtensionInstitucional { get; set; }
        public string? Correo { get; set; }
        public string? CorreoInstitucional { get; set; }
        public int? NivelEducativoId { get; set; }
        public int? OcupacionId { get; set; }
        public string? Dui { get; set; }
        public string? Nit { get; set; }
        public string? Isss { get; set; }
        public string? Nup { get; set; }
        public int? InstPrevisionalId { get; set; }
        public string? NumMarcacion { get; set; }
        public string? NumCuenta { get; set; }
        public int? InstBancoId { get; set; }
        public string? LineaTrabajoId { get; set; }
        public string? Partida { get; set; }
        public string? Subpartida { get; set; }
        public int? TipoContratoId { get; set; }
        public double? Salario { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaRenuncia { get; set; }
        public byte? Jefatura { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? Sede { get; set; }
        public string? NumMarcacionN { get; set; }
        public int? Institucion { get; set; }
        public string? Foto { get; set; }
    }
}
