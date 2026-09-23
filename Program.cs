
const int longitudMinimaCodigo = 6;
int solicitudesRegistradas = 0;

Console.WriteLine("==========================================");
Console.WriteLine(" SISTEMA DE SOPORTE ACADÉMICO");
Console.WriteLine("==========================================");

bool continuar = true;

while (continuar)
{
    MostrarMenu();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine() ?? "";

    if (opcion == "1")
    {
        Console.WriteLine("\nREGISTRO DE SOLICITUD");

        Console.Write("Código del estudiante: ");
        string codigo = Console.ReadLine() ?? "";

        if (!ValidarCodigoEstudiante(codigo, longitudMinimaCodigo))
        {
            Console.WriteLine("Error: el código debe tener al menos 6 caracteres.");
            continue;
        }

        Console.Write("Nombre del estudiante: ");
        string nombre = Console.ReadLine() ?? "";

        if (!ValidarTextoObligatorio(nombre))
        {
            Console.WriteLine("Error: el nombre es obligatorio.");
            continue;
        }

        Console.Write("Tipo de consulta: ");
        string tipo = Console.ReadLine() ?? "";

        if (!ValidarTipoConsulta(tipo))
        {
            Console.WriteLine("Error: tipo de consulta no válido.");
            continue;
        }

        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine() ?? "";

        if (!ValidarTextoObligatorio(descripcion))
        {
            Console.WriteLine("Error: la descripción es obligatoria.");
            continue;
        }

        string prioridad = AsignarPrioridad(tipo);

        MostrarResumen(
            codigo,
            nombre,
            tipo,
            descripcion,
            prioridad
        );

        solicitudesRegistradas++;
    }
    else if (opcion == "2")
    {
        continuar = false;
    }
    else
    {
        Console.WriteLine("Opción no válida. Seleccione 1 o 2.");
    }
}

Console.WriteLine($"\nTotal de solicitudes registradas: {solicitudesRegistradas}");
Console.WriteLine("Programa finalizado.");


// R2: Validación del código.
static bool ValidarCodigoEstudiante(string codigo, int longitudMinima)
{
    return !string.IsNullOrWhiteSpace(codigo) &&
           codigo.Length >= longitudMinima;
}


// R3: Validación del tipo de consulta.
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

    return tiposPermitidos.Contains(
        tipoConsulta.Trim().ToLower()
    );
}


// R4: Menú principal.
static void MostrarMenu()
{
    Console.WriteLine("\n==========================================");
    Console.WriteLine("       SOPORTE ACADÉMICO");
    Console.WriteLine("==========================================");
    Console.WriteLine("1. Registrar solicitud");
    Console.WriteLine("2. Salir");
    Console.WriteLine("==========================================");
}


// R5: Asignación de prioridad.
static string AsignarPrioridad(string tipoConsulta)
{
    string tipo = tipoConsulta.Trim().ToLower();

    if (tipo == "matricula" || tipo == "pagos")
        return "Alta";

    if (tipo == "constancia")
        return "Media";

    return "Baja";
}


// R6: Validación de texto obligatorio.
static bool ValidarTextoObligatorio(string texto)
{
    return !string.IsNullOrWhiteSpace(texto);
}


// R7 y R8: Resumen mediante parámetros.
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