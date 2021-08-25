using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLab01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";

            String opcion;


            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos numeros");
                Console.WriteLine("[2] Imprimir la raíz cuadrada de los 10 primeros números enteros");
                Console.WriteLine("[3] Resta de dos numeros");
                Console.WriteLine("[4] Multiplicación de dos numeros");
                Console.WriteLine("[5] División de dos numeros");
                Console.WriteLine("[6] Imprimir los 10 primeros números primos");
                Console.WriteLine("[7] Conversión de grados Celsius a Fahrenheit");
                Console.WriteLine("[8] Conversión de grados Fahrenheit a Celsius");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opción y presione ENTER");
                opcion = Console.ReadLine();

                int a = 0, b =0;
                int gradosCelsius=0, gradosFahrenheit=0;

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Suma de dos Números");
                        a = PrimeroNumero();
                        b = SegundoNumero();

                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Calculando la raiz de los 10 primeros números...");
                        Raiz();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Resta de dos Números");
                        a = PrimeroNumero();
                        b = SegundoNumero();

                        Console.WriteLine("La resta de {0} y {1} es {2}", a, b, Resta(a, b));
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Multiplicación de dos Números");
                        a = PrimeroNumero();
                        b = SegundoNumero();

                        Console.WriteLine("La multiplicación de {0} y {1} es {2}", a, b, Multiplicacion(a, b));
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("División de dos Números");
                        a = PrimeroNumero();
                        b = SegundoNumero();

                        Console.WriteLine("La división de {0} y {1} es {2}", a, b, Division(a, b));
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Calculando los 10 primeros números primos...");
                        NumeroPrimo();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Ingrese los grados Celsius:");
                        gradosCelsius = Convert.ToInt32(Console.ReadLine());
                        gradosFahrenheit = ConvertirAGradosFahrenheit(gradosCelsius);
                        Console.WriteLine("{0}C° equivale a {1}F°",gradosCelsius,gradosFahrenheit);
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Ingrese los grados Fahrenheit:");
                        gradosFahrenheit = Convert.ToInt32(Console.ReadLine());
                        gradosCelsius = ConvertirAGradosCelsius(gradosFahrenheit);
                        Console.WriteLine("{0}F° equivale a {1}C°", gradosFahrenheit, gradosCelsius);
                        Console.ReadKey();
                        break;

                }
            } while (!opcion.Equals("0"));


        }

        //función para obtener el primer numero
        static int PrimeroNumero()
        {
            Console.WriteLine("Ingrese el primer numero:");
            int numero = Convert.ToInt32(Console.ReadLine());
            return numero;
        }

        //función para obtener el segundo numero
        static int SegundoNumero()
        {
            Console.WriteLine("Ingrese el segundo numero:");
            int numero = Convert.ToInt32(Console.ReadLine());
            return numero;
        }


        //función para calcular la suma de dos numero enteros
        static int Suma(int a,int b)
        {
            return a+b;
        }

        //función para calcular la resta de dos numero enteros
        static int Resta(int a, int b)
        {
            return a - b;
        }

        //función para calcular la raíz cuadrada de los 10 primeros números
        static void Raiz()
        {
            for (int i=1;i<=10;i++)
            {
                Console.WriteLine("la raiz cuadrada de {0} es {1}", i, Math.Sqrt(i));
            }
        }

        //función para calcular la multiplicación de dos numero enteros
        static int Multiplicacion(int a, int b)
        {
            return a * b;
        }

        //funcíón para calcular la división de dos numero enteros
        static int Division(int a, int b)
        {
            return a / b;
        }

        //función para calcular la división de dos numero enteros
        static void NumeroPrimo()
        {
            int cantidadPrimo = 1;
            int numero = 0;
            while (cantidadPrimo<=10)
            {

                if (EsPrimo(numero))
                {
                    Console.WriteLine("El {0} es un número primo", numero);
                    cantidadPrimo++;
                }
                numero++;
            }
        }

        //función para determinar si un número es primo
        static bool EsPrimo(int numero)
        {            
            int divisor = 1;
            int cont = 0;

            while (divisor <= numero)
            {
                if (numero % divisor == 0)
                {
                    cont++;
                }
                divisor++;
            }
            return cont == 2;
        }

        //función para convertir grados Fahrenheit a Celsius
        static int ConvertirAGradosCelsius(int grados)
        {            
            return (5*(grados - 32))/9;
        }

        //función para convertir grados Celsius a Fahrenheit
        static int ConvertirAGradosFahrenheit(int grados)
        {
            return ((9*grados)/5) + 32;
        }
    }
}
