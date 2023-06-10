using ws.expediente.Modelos.Dto;

namespace ws.expediente.Datos
{
    public class EmpleadoStore
    {
        public static List<EmpleadoDto> empleadoList= new List<EmpleadoDto>
        {
            new EmpleadoDto{Id="1",Nombres="prueba1",Apellidos="apellido1"},
            new EmpleadoDto{Id="2",Nombres="prueba2",Apellidos="apellido2"}
        };
    }
}
