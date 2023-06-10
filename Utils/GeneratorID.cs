namespace ws.expediente.Utils
{
    public class GeneratorId
    {
        // Generación de Unique Local Identifier
        public static string GetUlid()
        {
            var guid = Guid.NewGuid();
            return guid.ToString().Replace("-", string.Empty);
        }
    }
}
