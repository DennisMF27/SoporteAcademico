Console.WriteLine("==========================================");
Console.WriteLine(" SISTEMA DE SOPORTE ACADÉMICO");
Console.WriteLine("==========================================");

Console.WriteLine("\nREGISTRO DE SOLICITUD");

Console.Write("Código del estudiante: ");
string codigoEstudiante = Console.ReadLine() ?? "";

Console.Write("Nombre del estudiante: ");
string nombre = Console.ReadLine() ?? "";

Console.Write("Tipo de consulta: ");
string tipoConsulta = Console.ReadLine() ?? "";

Console.Write("Descripción de la solicitud: ");
string descripcion = Console.ReadLine() ?? "";

Console.WriteLine("\n------------------------------------------");
Console.WriteLine("SOLICITUD REGISTRADA");
Console.WriteLine("------------------------------------------");
Console.WriteLine($"Código: {codigoEstudiante}");
Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Tipo de consulta: {tipoConsulta}");
Console.WriteLine($"Descripción: {descripcion}");