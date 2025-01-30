using System;

internal class Program //Clase interna
{
    static void Main(string[] args) //Metodo principal del programa
    {
        ejercicio(); //Metodo secundario
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

        } while (true);
    }

    private static int menuOpciones() //Metodo secundario que permite la eleccion de una opcion.
    {
        int opcion; //Variable int para usar un numero que el usuario introduzca como opcion.
        do
        {
            Console.WriteLine("Elige una opcion:\n" + //Menu de seleccion de opciones
                "1.. Piedra\n" +
                "2.. Papel\n" +
                "3.. Tijera\n" +
                "4.. Salir");
            Console.Write("Opcion del jugador: ");

            string input = Console.ReadLine(); //Leer el valor introducido

            if (int.TryParse(input, out opcion) && (opcion >= 0 && opcion <= 4)) //Ver si el numero introducido no es mayor a 4.
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
        }
        else if (usuario == pc) //Empate si ambos valores son iguales
        {
            Console.WriteLine("Empate"); //Empatar el jeugo
        }
        else
        {
            Console.WriteLine("Perdiste"); //Perder el juego
        }
    }
}