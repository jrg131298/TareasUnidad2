using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2RamirezGarciaJesus
{
    class PMenu
    {
        static void Main(string[] args)
        {
            bool Salir = false, SalirProceso = false;
            int Opcion;
            do
            {
                try
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("-----------Practica Evaluativas 2-----------");
                        Console.Write("Ingresa la cantidad de numeros deseados: ");
                        int Cantidad = Convert.ToInt16(Console.ReadLine());
                        if(Cantidad <= 1)
                        {
                            Console.WriteLine("Debes ingresar un numero mayor a 1.\nPreciona cualquier tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            double[] Numeros = new double[Cantidad];
                            for (int Contador = 0; Contador < Cantidad; Contador++)
                            {
                                Console.Write("Ingresa el numero {0}: ", (Contador+1));
                                Numeros[Contador] = Convert.ToDouble(Console.ReadLine());
                            }
                            Proceso P = new Proceso(Numeros, Cantidad);
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("-----------Practica Evaluativas 2-----------");
                                Console.WriteLine("Ingresa el numero de la opcion que desees: ");
                                Console.WriteLine("1.- Encontrar el menor");
                                Console.WriteLine("2.- Encontrar el mayor");
                                Console.WriteLine("3.- Invertir los numeros");
                                Console.Write("R: ");
                                Opcion = Convert.ToInt32(Console.ReadLine());

                                switch (Opcion)
                                {
                                    case 1:
                                        P.Menor(Cantidad - 1);
                                        Console.WriteLine("Preciona cualquier tecla para continuar.");
                                        Console.ReadKey();
                                        SalirProceso = true;
                                        break;
                                    case 2:
                                        P.Mayor(Cantidad - 1);
                                        Console.WriteLine("Preciona cualquier tecla para continuar.");
                                        Console.ReadKey();
                                        SalirProceso = true;
                                        break;
                                    case 3:
                                        Console.WriteLine("\nSerie Normal");
                                        P.Normal(0);
                                        Console.WriteLine("\nSerie invertida");
                                        P.Invertida(Cantidad - 1);
                                        Console.WriteLine("\nPreciona cualquier tecla para continuar.");
                                        Console.ReadKey();
                                        SalirProceso = true;
                                        break;
                                    default:
                                        Console.WriteLine("Ingresaste algo erroneo.\nPreciona cualquier tecla para continuar.");
                                        Console.ReadKey();
                                        break;
                                }
                            } while (SalirProceso == false);
                        }

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-----------Practica Evaluativas 2-----------");
                            Console.WriteLine("Ingresa el numero de la opcion que desees: ");
                            Console.WriteLine("1.- Regresar al menu");
                            Console.WriteLine("2.- Salir del programa");
                            Console.Write("R: ");
                            Opcion = Convert.ToInt16(Console.ReadLine());
                            if (Opcion == 1)
                            {
                                SalirProceso = true;
                                Salir = false;
                            }
                            else if (Opcion == 2)
                            {
                                SalirProceso = true;
                                Salir = true;
                            }
                            else
                            {
                                Console.WriteLine("Ingresaste algo erroneo.\nPreciona cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (SalirProceso == false);
                    } while (Salir == false);
                }
                catch
                {
                    Console.WriteLine("A ocurrido un erroneo.\nPreciona cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                finally
                { }
            } while (Salir == false);
            Console.WriteLine("Preciona cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }

    class Proceso
    {
        private double[] Numeros;
        private double Nmenor, Nmayor;
        private int Cantidad;
        public Proceso(double[] Numeros, int Cantidad)
        {
            this.Numeros = Numeros;
            this.Cantidad = Cantidad;
        }

        public int Menor(int Contador)
        {
            if(Contador == (Cantidad - 1))
            {
                if (Numeros[Contador - 1] > Numeros[Contador])
                {
                    Nmenor = Numeros[Contador];
                }
                else
                {
                    Nmenor = Numeros[Contador - 1];
                }
                return (Menor(Contador-2));
            }
            else if(Contador <= 0)
            {
                if(Contador == 0)
                {
                    if (Nmenor > Numeros[Contador])
                    {
                        Nmenor = Numeros[Contador];
                    }
                    else { }
                }
                else { }
                Console.WriteLine("El menor es: {0}", Nmenor);
                return 1;
            }
            else
            {
                if (Nmenor > Numeros[Contador - 1])
                {
                    Nmenor = Numeros[Contador - 1];
                }
                else
                { }
                return (Menor(Contador - 1));
            }
        }

        public int Mayor(int Contador)
        {
            if (Contador == (Cantidad - 1))
            {
                if (Numeros[Contador - 1] > Numeros[Contador])
                {
                    Nmayor = Numeros[Contador - 1];
                }
                else
                {
                    Nmayor = Numeros[Contador];
                }
                return (Mayor(Contador - 2));
            }
            else if (Contador <= 0)
            {
                if (Contador == 0)
                {
                    if (Nmayor < Numeros[Contador])
                    {
                        Nmayor = Numeros[Contador];
                    }
                    else { }
                }
                else { }
                Console.WriteLine("El mayor es: {0}", Nmayor);
                return 1;
            }
            else
            {
                if (Nmayor < Numeros[Contador - 1])
                {
                    Nmayor = Numeros[Contador - 1];
                }
                else
                { }
                return (Mayor(Contador - 1));
            }
        }
        public int Invertida(int Contador)
        {
            if (Contador == 0)
            {
                Console.Write("{0} ", Numeros[Contador]);
                return 1;
            }
            else
            {
                Console.Write("{0} ", Numeros[Contador]);
                return Invertida(Contador - 1);
            }
        }

        public int Normal(int Contador)
        {
            if (Contador == (Cantidad - 1))
            {
                Console.Write("{0} ",Numeros[Contador]);
                return 1;
            }
            else
            {
                Console.Write("{0} ", Numeros[Contador]);
                return Normal(Contador + 1);
            }
        }
    }
}
