﻿using System;

namespace HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola, como te llamas :");

            String nombre = Console.ReadLine();

            Console.WriteLine("Mucho gusto en conocerte " + nombre);
        }
    }
}
