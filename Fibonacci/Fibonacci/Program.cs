using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Fibonacci
{
    class Menu
    {
        static void Main(string[] args)
        {
            Int16 CantidadNumeros, Opcion = 0; 
            Int32 Contador = 3;
            Stopwatch ST = new Stopwatch();
            bool Salir = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Sucesion fibonacci");
                try
                {
                    Console.Write("Ingresa el tope de la sucesion: ");
                    CantidadNumeros = Convert.ToInt16(Console.ReadLine());

                    if (CantidadNumeros > 0)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Sucesion fibonacci");
                            Console.WriteLine("Ingresa ell numero de la opcion que desees: ");
                            Console.WriteLine("1.- Iteraccion");
                            Console.WriteLine("2.- Recursividad");
                            Console.Write("R: ");
                            Opcion = Convert.ToInt16(Console.ReadLine());
                            if (Opcion == 1)
                            {
                                Proceso P = new Proceso(CantidadNumeros);
                                ST.Start();
                                P.Sucesion();
                                Console.WriteLine("Tiempo: {0}", ST.Elapsed.ToString());
                                Console.WriteLine("Presiona una tecla para continuar.");
                                Console.ReadKey();
                                ST.Stop();
                                Salir = true;
                            }
                            else if (Opcion == 2)
                            {
                                Proceso P = new Proceso(CantidadNumeros);
                                ST.Start();
                                Console.WriteLine("\nSucesion.");
                                P.Sucesion2(Contador);
                                Console.WriteLine("Tiempo: {0}", ST.Elapsed.ToString());
                                Console.WriteLine("Presiona una tecla para continuar.");
                                Console.ReadKey();
                                ST.Stop();
                                Salir = true;
                            }
                            else
                            {
                                Console.WriteLine("Ingresaste un valor erroneo.\nPreciona cualquier boton para continuar.");
                            }
                        } while (Salir == false);
                    }
                    else
                    {
                        Console.WriteLine("\nDebes ingresar un numero mayor a 0.");
                    }
                }
                catch
                {
                    Console.WriteLine("A ocurrido un error.");
                }
                finally { Console.WriteLine("Gracias por utilizar el programa.");}
                Console.WriteLine("Presiona un boton para continuar.");
                Console.ReadKey();
            } while (Salir == false);
        }
    }

    class Proceso
    {
        private Int16 CantidadNumeros;
        private Int32 Menor = 0, Mayor = 1, Auxiliar;
        public Proceso(Int16 CantidadNumeros)
        {
            this.CantidadNumeros = CantidadNumeros;
        }

        public void Sucesion()
        {
            Console.WriteLine("\nSucesion.");
            if(CantidadNumeros == 1)
            {
                Console.Write("0");
            }
            else if(CantidadNumeros == 2)
            {
                Console.Write("0, 1");
            }
            else
            { //0,1,1,2,3,5,8,13,21,34
                Console.Write("0, 1");
                for (Int16 Contador2 = 3; Contador2 <= CantidadNumeros; Contador2++)
                {
                    Auxiliar = Menor + Mayor;
                    Menor = Mayor;
                    Mayor = Auxiliar;
                    Console.Write(", {0}", Auxiliar);
                }
            }
            Console.WriteLine();
        }

        public int Sucesion2(Int32 Contador)
        {
            if (CantidadNumeros == 1)
            {
                Console.WriteLine("0");
                return 1;
            }
            else if(CantidadNumeros == 2)
            {
                Console.WriteLine("0, 1");
                return 1;
            }
            else
            {
                if(Contador > CantidadNumeros)
                {
                    Console.WriteLine();
                    return 1;
                }
                else
                {
                    if(Contador == 3)
                    {
                        Console.Write("0, 1");
                    }
                    Auxiliar = Menor + Mayor;
                    Menor = Mayor;
                    Mayor = Auxiliar;
                    Console.Write(", {0}", Auxiliar);
                    return (Sucesion2((Contador + 1)));
                }
            }
        }
        ~Proceso()
        {
            Console.WriteLine("Memoria del objeto Proceso liberada.");
        }
    }
}
