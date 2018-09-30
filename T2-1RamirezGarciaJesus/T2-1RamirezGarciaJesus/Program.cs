using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_1RamirezGarciaJesus
{
    class Menu
    {
        static void Main(string[] args)
        {
            Int16 CantidadNumeros;
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
                        Proceso p = new Proceso(CantidadNumeros);
                        p.Sucesion();
                        Salir = true;
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
                finally { Console.WriteLine("Gracias por utilizar el programa."); }
                Console.WriteLine("Presiona un boton para continuar.");
                Console.ReadKey();
            } while (Salir == false);
        }
    }

    class Proceso
    {
        private Int16 CantidadNumeros;
        public Proceso(Int16 CantidadNumeros)
        {
            this.CantidadNumeros = CantidadNumeros;
        }

        public void Sucesion()
        {
            Console.WriteLine("\nSucesion.");
            if (CantidadNumeros == 1)
            {
                Console.Write("0");
            }
            else if (CantidadNumeros == 2)
            {
                Console.Write("0, 1");
            }
            else
            { //0,1,1,2,3,5,8,13,21,34
                Int32 Menor = 0, Mayor = 1, Auxiliar;
                Console.Write("0, 1");
                for (Int16 Contador = 3; Contador <= CantidadNumeros; Contador++)
                {
                    Auxiliar = Menor + Mayor;
                    Menor = Mayor;
                    Mayor = Auxiliar;
                    Console.Write(", {0}", Auxiliar);
                }
            }
            Console.WriteLine();
        }

        ~Proceso()
        {
            Console.WriteLine("Memoria del objeto Proceso liberada.");
        }
    }
}
