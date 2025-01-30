using System; 
class Circle //Clase donde se ejecuta el programa
{
    static void Main(string[] args) //Metodo principal
    {
        Console.Write("Ingresa un radio: "); //Solicitar ingreso de radio.
        double rad = Convert.ToDouble(Console.ReadLine()); //Convertir el tipo de valor con funciones
        double area = 3.14 * rad * rad; //Uso del numero PI para calcular el area.
        Console.WriteLine("El area es: " + area); //Imprimir resultado final
    }
}