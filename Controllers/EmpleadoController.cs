using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ws.expediente.Datos;
using ws.expediente.Modelos;
using ws.expediente.Modelos.Dto;
using ws.expediente.Utils;
//si lo envio
namespace ws.expediente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly PersonaDbContext _db;
        public EmpleadoController(ILogger<EmpleadoController> logger, PersonaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EmpleadoDto>> GetEmpleados()
        {
            _logger.LogInformation("Obtener los Empleados");
            return Ok(_db.Empleados.ToList());
        }

        [HttpGet("{id}", Name ="GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmpleadoDto> GetEmpleado(string id)
        {
            if(id == "0"){
                _logger.LogError("Error al traer empleado con Id " + id);
                return BadRequest();
            }
            //var empleado= EmpleadoStore.empleadoList.FirstOrDefault(v => v.Id == id);
            var empleado=_db.Empleados.FirstOrDefault(v => v.Id == id);
            if(empleado == null) { 
                return NotFound(); 
            }
            return Ok(empleado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmpleadoDto> CrearEmpleado([FromBody] EmpleadoDto empleadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.Empleados.FirstOrDefault(v => v.Nombres.ToLower() == empleadoDto.Nombres.ToLower()) != null)
            {
                ModelState.AddModelError("Error", "El Empleado con ese Nombre ya Existe!");
                return BadRequest(ModelState);
            }
            if (empleadoDto == null)
            {
                return BadRequest(empleadoDto);
            }
            /*if (empleadoDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }*/
            // Mapear cada valor para ejecutar store procedure

            //empleadoDto.Id = EmpleadoStore.empleadoList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            //EmpleadoStore.empleadoList.Add(empleadoDto);
            //return CreatedAtRoute("GetEmpleado", new { id = empleadoDto.Id }, empleadoDto);

            //Bajo SQL
            string id = GeneratorId.GetUlid();
            //empleadoDto.Id = id;
            Empleado modelo = new()
            {
                Id= id,
                Apellidos = empleadoDto.Apellidos,
                Nombres = empleadoDto.Nombres,
                SexoId = empleadoDto.SexoId,
                EstadoFamId = empleadoDto.EstadoFamId,
                Direccion = empleadoDto.Direccion
            };
            _db.Empleados.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetEmpleado", empleadoDto);


        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmpleado(string id)
        {
            if(id == "0")
            {
                return BadRequest();
            }
            var empleado = EmpleadoStore.empleadoList.FirstOrDefault(v => v.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            EmpleadoStore.empleadoList.Remove(empleado);
            return NoContent();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmpleado(string id, [FromBody] EmpleadoDto empleadoDto)
        {
            if(empleadoDto == null || id != empleadoDto.Id)
            {
                return BadRequest();
            }
            var empleado = EmpleadoStore.empleadoList.FirstOrDefault(v => v.Id == id);
            empleado.Nombres = empleadoDto.Nombres;
            empleado.Apellidos = empleadoDto.Apellidos;
            return NoContent();
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateParcialEmpleado(string id, JsonPatchDocument<EmpleadoDto> patchDto)
        {
            if (patchDto == null || id == "")
            {
                return BadRequest();
            }
            var empleado = EmpleadoStore.empleadoList.FirstOrDefault(v => v.Id == id);
            patchDto.ApplyTo(empleado, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
