const int longitudMinimaCodigo = 6;

Console.WriteLine("==========================================");
Console.WriteLine(" SISTEMA DE SOPORTE ACADÉMICO");
Console.WriteLine("==========================================");

MostrarMenu();

Console.WriteLine("\nREGISTRO DE SOLICITUD");

Console.Write("Código del estudiante: ");
string codigoEstudiante = Console.ReadLine() ?? "";

if (!ValidarCodigoEstudiante(codigoEstudiante, longitudMinimaCodigo))
{
    Console.WriteLine("Error: el código no puede estar vacío y debe tener al menos 6 caracteres.");
    return;
}

Console.Write("Nombre del estudiante: ");
string nombre = Console.ReadLine() ?? "";

if (!ValidarTextoObligatorio(nombre))
{
    Console.WriteLine("Error: el nombre del estudiante es obligatorio.");
    return;
}

Console.Write("Tipo de consulta: ");
string tipoConsulta = Console.ReadLine() ?? "";

if (!ValidarTipoConsulta(tipoConsulta))
{
    Console.WriteLine("Error: tipo de consulta no válido.");
    Console.WriteLine("Tipos permitidos: matricula, pagos, constancia, plataforma u otro.");
    return;
}

Console.Write("Descripción de la solicitud: ");
string descripcion = Console.ReadLine() ?? "";

if (!ValidarTextoObligatorio(descripcion))
{
    Console.WriteLine("Error: la descripción de la solicitud es obligatoria.");
    return;
}

string prioridad = AsignarPrioridad(tipoConsulta);

MostrarResumen(
    codigoEstudiante,
    nombre,
    tipoConsulta,
    descripcion,
    prioridad
);


// R2: Valida el código del estudiante.
static bool ValidarCodigoEstudiante(string codigo, int longitudMinima)
{
    return !string.IsNullOrWhiteSpace(codigo) &&
           codigo.Length >= longitudMinima;
}


// R3: Valida el tipo de consulta.
static bool ValidarTipoConsulta(string tipoConsulta)
{
    string[] tiposPermitidos =
    {
        "matricula",
        "pagos",
        "constancia",
        "plataforma",
        "otro"
    };

    return tiposPermitidos.Contains(tipoConsulta.ToLower());
}


// R4: Muestra el menú principal.
static void MostrarMenu()
{
    Console.WriteLine("==========================================");
    Console.WriteLine("       SOPORTE ACADÉMICO");
    Console.WriteLine("==========================================");
    Console.WriteLine("1. Registrar solicitud");
    Console.WriteLine("2. Salir");
    Console.WriteLine("==========================================");
}


// R5: Asigna la prioridad según el tipo de consulta.
static string AsignarPrioridad(string tipoConsulta)
{
    if (tipoConsulta.ToLower() == "matricula" ||
        tipoConsulta.ToLower() == "pagos")
    {
        return "Alta";
    }

    if (tipoConsulta.ToLower() == "constancia")
    {
        return "Media";
    }

    return "Baja";
}


// R6: Valida que un texto obligatorio no esté vacío.
static bool ValidarTextoObligatorio(string texto)
{
    return !string.IsNullOrWhiteSpace(texto);
}


// R7 y R8: Muestra el resumen usando parámetros.
static void MostrarResumen(
    string codigo,
    string nombre,
    string tipoConsulta,
    string descripcion,
    string prioridad)
{
    Console.WriteLine("\n------------------------------------------");
    Console.WriteLine("SOLICITUD REGISTRADA");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"Código: {codigo}");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Tipo de consulta: {tipoConsulta}");
    Console.WriteLine($"Descripción: {descripcion}");
    Console.WriteLine($"Prioridad: {prioridad}");
}


// R9: Las variables se mantienen dentro del alcance
// donde son necesarias y los datos se pasan mediante parámetros.