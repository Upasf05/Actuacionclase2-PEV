using System;

internal class Program //Clase interna
{
    static int vidasUsuario = 3; //Vidas del jugador
    static int vidasPc = 3; //Vidas del computador

    static void Main(string[] args) //Metodo principal del programa
    {
        juegoPrincipal(); //Funcion principal del programa
    }

    private static void juegoPrincipal() //Funcion principal privada
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
            Console.WriteLine($"El computador saco: {(randomPc == 1 ? "Piedra" : randomPc == 2 ? "Papel" : "Tijera")}");

            if ((opcionUsuario == 1 && randomPc == 3) || (opcionUsuario == 2 && randomPc == 1) || (opcionUsuario == 3 && randomPc == 2)) //Bloque if que baraja opciones de si se gano o perdio en base a la logica del juego piedra papel o tijera
            {
                Console.WriteLine("Has ganado!");
                vidasPc--;
            }
            else if (opcionUsuario == randomPc)
            {
                Console.WriteLine("Empate");
            }
            else
            {
                Console.WriteLine("Perdiste");
                vidasUsuario--;
            }

            Console.WriteLine($"Vidas restantes - Usuario: {vidasUsuario} | PC: {vidasPc}\n"); //Mostrar vidas del jugador y el PC
            
            if (vidasUsuario == 0 || vidasPc == 0) //If para mostrar un ganador si el otro jugador se queda sin vidas
            {
                mostrarGanador(); //Llamar funcion de mostrar ganador
                break;
            }
        } while (juego());
    }

    private static int menuOpciones() //Funcion donde se muestra el menu de opcion
    {
        int opcion; //Menu de opciones
        do
        {
            Console.WriteLine("Elige una opcion:");
            Console.WriteLine("1.. Piedra");
            Console.WriteLine("2.. Papel");
            Console.WriteLine("3.. Tijera");
            Console.WriteLine("4.. Salir");
            Console.Write("Opcion del jugador: ");

            string input = Console.ReadLine(); //Leer un numero introducido
            if (int.TryParse(input, out opcion) && opcion >= 1 && opcion <= 4) //Ver si el numero esta en el rango indicado
            {
                return opcion;
            }
            else
            {
                Console.WriteLine("Ingrese un numero valido entre 1 y 4");
            }
        } while (true);
    }

    private static void mostrarGanador() //Mostrar el ganador de una partida
    {
        if (vidasUsuario == 0) //Bloque if que muestra el ganador
        {
            Console.WriteLine("PC gana la partida");
        }
        else if (vidasPc == 0)
        {
            Console.WriteLine("Has ganado la partida!");
        }
        else
        {
            Console.WriteLine("La partida ha terminado en un empate");
        }
    }

    private static bool juego() //Continuar el juego o no despues de una partida
    {
        do
        {
            Console.Write("Desea continuar con el juego? (s/n): "); //Mensaje de continuar
            string respuesta = Console.ReadLine().Trim().ToLower(); //Leer la respuesta

            if (respuesta == "s") //Continuar si se introdujo s
            {
                return true;
            }
            else if (respuesta == "n") //Salir del jeugo si se introdujo n
            {
                Console.WriteLine("Gracias por jugar!");
                return false;
            }
            else //Mensaje si se introdujo un valor ajeno a s o n
            {
                Console.WriteLine("Ingresa s para continuar o n para salir");
            }
        } while (true);
    }
}
