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
                Console.WriteLine("[2] Imprimir la raiz cuadrada de los 10 primeros numeros enteros");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opción y presione ENTER");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el primer numero:");
                        int a = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese el segundo numero:");
                        int b = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("La suma de {0} y {1} = {2}", a, b, Suma(a, b));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();
                        break;

                }
            } while (!opcion.Equals("0"));



            

           
            

        }

        //funcion para calcular la suma de dos numero enteros
        static int Suma(int a,int b)
        {
            return a+b;
        }

        static int Resta(int a, int b)
        {
            return a - b;
        }

        static void Raiz()
        {
            for (int i=1;i<=10;i++)
            {
                Console.WriteLine("la raiz cuadrada de {0} es {1}", i, Math.Sqrt(i));
            }
        }

    }
}
