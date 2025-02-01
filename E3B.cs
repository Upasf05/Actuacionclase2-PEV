using System;

internal class Program //Clase interna
{
    static int vidasUsuario = 3; // Vidas del jugador
    static int vidasPc = 3; // Vidas del computador

    static void Main(string[] args) //Metodo principal del programa
    {
        ejercicio(); //Metodo secundario
        mostrarGanador(); // Metodo para mostrar el ganador
    }

    private static void ejercicio() //Metodo secundario donde se ejecuta un ejercicio
    {
        do
        {
            int opcionUsuario = menuOpciones(); //Metodo secundario
            if (opcionUsuario == 4) //Salir del juego si se pulsa 4
            {
                Console.WriteLine("Saliendo del juego..."); //Abandonar el juego
                break;
            }

            int randomPc = new Random().Next(1, 4); //Genera un numero aleatorio que sera la opcion que escoja el computador. Sera diferente en cada partida
            logicaJuego(opcionUsuario, randomPc);

            if (vidasUsuario == 0 || vidasPc == 0) // Verificar si alguno se quedo sin vidas
            {
                break;
            }

        } while (juego()); // Llamar a la función para continuar o salir del juego
    }

    private static int menuOpciones() //Metodo secundario que permite la eleccion de una opcion.
    {
        int opcion; //Variable int para usar un numero que el usuario introduzca como opcion.
        do
        {
            Console.WriteLine("Elige una opcion:");
            Console.WriteLine("1.. Piedra");
            Console.WriteLine("2.. Papel");
            Console.WriteLine("3.. Tijera");
            Console.WriteLine("4.. Salir");
            Console.Write("Opcion del jugador: ");

            string input = Console.ReadLine(); //Leer el valor introducido

            if (int.TryParse(input, out opcion) && (opcion >= 1 && opcion <= 4)) //Ver si el numero introducido no es mayor a 4.
            {
                return opcion; //Retornar el valor si cumple con los parametros
            }
            else
            {
                Console.WriteLine("Ingrese un numero valido entre 1 y 4");
            }
        } while (true);
    }

    private static void logicaJuego(int usuario, int pc) //Metodo secundario que muestra el resultado usando el int que el computador selecciono con ayuda de la funcion random
    {
        Console.WriteLine($"El computador saco: {(pc == 1 ? "Piedra" : pc == 2 ? "Papel" : "Tijera")}");

        if ((usuario == 1 && pc == 3) || (usuario == 2 && pc == 1) || (usuario == 3 && pc == 2)) //Bloque if que baraja opciones de si se gano o perdio en base a la logica del juego piedra papel o tijera
        {
            Console.WriteLine("Has ganado!"); //Ganar el juego
            vidasPc--; // Restar una vida al PC
        }
        else if (usuario == pc) //Empate si ambos valores son iguales
        {
            Console.WriteLine("Empate"); //Empatar el juego
        }
        else
        {
            Console.WriteLine("Perdiste"); //Perder el juego
            vidasUsuario--; // Restar una vida al usuario
        }

        Console.WriteLine($"Vidas restantes - Usuario: {vidasUsuario} | PC: {vidasPc}\n");
    }

    private static void mostrarGanador() //Funcion que muestra al ganador de la partida
    {
        if (vidasUsuario == 0) //Bloque if que muestra el ganador en base a quien se haya quedado sin vidas
        {
            Console.WriteLine("PC gana la partida"); //Perder la partida
        }
        else if (vidasPc == 0) //Else if si es el otro quien se quedo sin vidas
        {
            Console.WriteLine("Has ganado la partida!"); //Ganar la partida
        }
        else
        {
            Console.WriteLine("La partida ha terminado en un empate"); //
        }
    }

    private static bool juego() // Metodo para preguntar si se quiere continuar
    {
        do
        {
            Console.Write("Desea continuar con el juego? (s/n): ");
            string respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta == "s")
            {
                return true; // Continuar el juego
            }
            else if (respuesta == "n")
            {
                Console.WriteLine("Gracias por jugar!");
                return false; // Salir del juego
            }
            else
            {
                Console.WriteLine("Por favor, ingrese 's' para continuar o 'n' para salir.");
            }

        } while (true);
    }
}
