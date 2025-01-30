using System;

class Program //Clase principal del programa
{
    static int sumaTotal = 0; //Establecer 0 como el valor por defecto de la suma total

    static void Main() //Metodo principal del programa
    {
        Console.WriteLine("Introduce numeros enteros para sumarlos (0 para finalizar):");

        while (true) //Bucle while donde se ejecuta el programa
        {
            Console.Write("Numero: ");
            string input = Console.ReadLine(); //Introducir un numero y leerlo

            if (int.TryParse(input, out int numero)) //Ver si se introdujo un valor numerico
            {
                if (numero == 0) //Finazlizar el bucle si se introduce el numero 0
                {
                    break; 
                }
                else //Continuar el bucle si se introduce un numero que no sea 0
                {
                    Agregar_num(numero); //Agregar un numero al bucle para que despues se sume
                }
            }
            else //Mensaje si se introduce un valor no numerico
            {
                Console.WriteLine("Introduzca un numero valido.");
            }
        }
        
        Console.WriteLine($"La suma total es: {sumaTotal}"); //Imprimir el resultado cuando finalice el proceso.
    }

    // Funcion para ir agregando un numero a la suma total
    static void Agregar_num(int numero)
    {
        sumaTotal += numero;
    }
}