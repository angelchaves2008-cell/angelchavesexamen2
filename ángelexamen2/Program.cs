using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Hospital San Rafael - Opcion A (censo administrativo)

// N = ultimo digito del carne (8) + 10 = 18

// Cambie "NombreApellido" por su primer nombre y apellido juntos (ej. PedroPerez)

namespace NombreApellido

{

    internal class Program

    {

        const int N = 18;

        // Arreglos paralelos: la misma posicion es el mismo paciente

        static string[] nombres = new string[N];

        static string[] cedulas = new string[N];

        static int[] estados = new int[N]; // 0 = libre, 1 = activo, 2 = alta

        static int total = 0;

        static void Main(string[] args)

        {

            Console.OutputEncoding = Encoding.UTF8;

            // Inicializacion de valores

            InicializarValores();

            int opcion = 0;

            while (opcion != 6)

            {

                MostrarMenu();

                string textoOpcion = Console.ReadLine() ?? "";

                // Validacion: la opcion debe ser un numero del 1 al 6

                if (!int.TryParse(textoOpcion, out opcion))

                {

                    Console.WriteLine("Opción inválida");

                    opcion = 0;

                    continue;

                }

                switch (opcion)

                {

                    case 1:

                        RegistrarPaciente();

                        break;

                    case 2:

                        ListarPacientes();

                        break;

                    case 3:

                        BuscarPaciente();

                        break;

                    case 4:

                        DarDeAlta();

                        break;

                    case 5:

                        MostrarReportes();

                        break;

                    case 6:

                        Console.WriteLine("Saliendo del sistema...");

                        break;

                    default:

                        Console.WriteLine("Opción inválida");

                        break;

                }

            }

        }

        // Pone los arreglos vacios y total en 0

        static void InicializarValores()

        {

            total = 0;

            for (int indice = 0; indice < N; indice++)

            {

                nombres[indice] = "";

                cedulas[indice] = "";

                estados[indice] = 0;

            }

        }

        static void MostrarMenu()

        {

            Console.WriteLine();

            Console.WriteLine("===== HOSPITAL SAN RAFAEL =====");

            Console.WriteLine("1. Registrar paciente");

            Console.WriteLine("2. Listar pacientes");

            Console.WriteLine("3. Buscar por cédula");

            Console.WriteLine("4. Dar de alta");

            Console.WriteLine("5. Reportes");

            Console.WriteLine("6. Salir");

            Console.Write("Elija una opción: ");

        }

        // Recorre de 0 a total - 1 buscando la cedula. Devuelve la posicion o -1

        static int BuscarPosicion(string cedula)

        {

            for (int indice = 0; indice < total; indice++)

            {

                if (cedulas[indice] == cedula)

                {

                    return indice;

                }

            }

            return -1;

        }

        static string TextoEstado(int estado)

        {

            if (estado == 1)

            {

                return "Activo";

            }

            if (estado == 2)

            {

                return "Alta";

            }

            return "Libre";

        }

        static void RegistrarPaciente()

        {

            // Primero reviso que haya espacio

            if (total >= N)

            {

                Console.WriteLine("Sin espacio");

                return;

            }

            Console.Write("Nombre del paciente: ");

            string nombrePaciente = (Console.ReadLine() ?? "").Trim();

            Console.Write("Cédula: ");

            string cedulaPaciente = (Console.ReadLine() ?? "").Trim();

            if (nombrePaciente == "" || cedulaPaciente == "")

            {

                Console.WriteLine("Datos vacíos");

                return;

            }

            if (BuscarPosicion(cedulaPaciente) != -1)

            {

                Console.WriteLine("Cédula repetida");

                return;

            }

            // Guardo en la posicion total de los tres arreglos

            nombres[total] = nombrePaciente;

            cedulas[total] = cedulaPaciente;

            estados[total] = 1;

            total++;

            Console.WriteLine("Paciente registrado");

        }

        static void ListarPacientes()

        {

            if (total == 0)

            {

                Console.WriteLine("No hay pacientes");

                return;

            }

            for (int indice = 0; indice < total; indice++)

            {

                Console.WriteLine((indice + 1) + ". " + nombres[indice] + " - " +

                    cedulas[indice] + " - " + TextoEstado(estados[indice]));

            }

        }

        static void BuscarPaciente()

        {

            Console.Write("Cédula a buscar: ");

            string cedulaPaciente = (Console.ReadLine() ?? "").Trim();

            int posicion = BuscarPosicion(cedulaPaciente);

            if (posicion == -1)

            {

                Console.WriteLine("No encontrado");

            }

            else

            {

                Console.WriteLine(nombres[posicion] + " - " + cedulas[posicion] +

                    " - " + TextoEstado(estados[posicion]));

            }

        }

        static void DarDeAlta()

        {

            Console.Write("Cédula del paciente a dar de alta: ");

            string cedulaPaciente = (Console.ReadLine() ?? "").Trim();

            int posicion = BuscarPosicion(cedulaPaciente);

            if (posicion == -1)

            {

                Console.WriteLine("No encontrado");

            }

            else if (estados[posicion] == 2)

            {

                Console.WriteLine("Ya tiene alta");

            }

            else

            {

                estados[posicion] = 2;

                Console.WriteLine("Alta realizada");

            }

        }

        static void MostrarReportes()

        {

            int activos = 0;

            int altas = 0;

            for (int indice = 0; indice < total; indice++)

            {

                if (estados[indice] == 1)

                {

                    activos++;

                }

                else if (estados[indice] == 2)

                {

                    altas++;

                }

            }

            Console.WriteLine("===== REPORTE =====");

            Console.WriteLine("Activos: " + activos);

            Console.WriteLine("Altas: " + altas);

            Console.WriteLine("Espacios libres: " + (N - total));

        }

    }

}

