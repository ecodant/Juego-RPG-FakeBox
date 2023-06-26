using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Juego_RPG
{

    class Jugador
    {
        private string name;
        private int health;
        private int comodin;

        public Jugador(string personaje, int limite)
        {
            name = personaje;
            health = limite;
            comodin = 1;
        }

        public string get_Name()
        {
            return name;
        }

        public void set_Name(string newName)
        {
            name = newName;
        }

        public int get_Health()
        {
            return health;
        }

        public void set_Health(int newHealth)
        {
            health = newHealth;
        }

        public int get_Comodin()
        {
            return comodin;
        }

        public void set_Comodin(int newComodin)
        {
            comodin = newComodin;
        }
        public List<string> Ataques1()
        {
            List<string> Ataques = new List<string>()
        {
            "Pinza Fuerte",
            "Pinza Cortante",
            "Pinza Papiro",
            "Mano Negra"
        };
            return Ataques;
        }

        public List<string> Ataques2()
        {
            List<string> Ataques = new List<string>()
        {
            "PlanktonMAN",
            "PlanktonCutter",
            "PlanktonGlowmoso",
            "Mano Negra"
        };
            return Ataques;
        }
        public int seleccion_Jugador(List<string> Ataques)
        {
            Console.Write("Los ataques disponibles son:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($" 1. {Ataques[0]}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($" 2. {Ataques[1]}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" 3. {Ataques[2]} ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"4. {Ataques[3]}");
            Console.ResetColor();

            int num;
            bool sentinel = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("¿Qué habilidad desea usar? (1,2,3,4): ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (num > 0 && num <= 4) sentinel = false;
                    else Console.WriteLine("El número debe se estar entre 1 y 4");

                }
                else Console.WriteLine("Eso que ingreso no es un número.");

            } while (sentinel);
            num -= 1;
            Console.ResetColor();
            Console.Clear();
            return num;

        }
        public int seleccion_Bot(List<string> Ataques)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, 3);
            return randomIndex;
        }
        public string Jugar(int turno1, int turno2, List<string> Ataques1, List<string> Ataques2)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Tu has seleccionado {Ataques1[turno1]}");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Tu enemigo ha selecionado {Ataques2[turno2]}");
            Console.ResetColor();
            Thread.Sleep(1000);
            return comparar_Respuestas(turno1 , turno2);
        }
        public string health_P1()
        {
            string barra = string.Empty;

            for (int i = 0; i < health; i++)
            {
                barra += "♥";
            }
            return barra;
        }
        public string health_P2()
        {
            string barra = string.Empty;

            for (int i = 0; i < health; i++)
            {
                barra += "♦";
            }
            return barra;
        }
        public string remove_Health(string vida_actual)
        {
            if (!string.IsNullOrEmpty(vida_actual))
            {
                vida_actual = vida_actual.Substring(0,vida_actual.Length - 1);
                Console.Write($"{vida_actual}\n");
            }
            return vida_actual;
        }

        private string comparar_Respuestas(int respuesta1, int respuesta2)
        {
            switch (respuesta2)
            {
                case 0:
                    switch (respuesta1)
                    {
                        case 0:
                            Console.WriteLine("¡Es un empate! Ninguno pierde salud.");
                            return "empate";
                        case 1:
                            Console.WriteLine("¡Gana tu enemigo! Pierdes un punto de salud.");
                            return "jugador 2";
                        case 2:
                            Console.WriteLine("¡Le quitas un punto! Bien hecho.");
                            return "jugador 1";
                        case 3:
                            Console.WriteLine("Vas con todo e.e");
                            return "comodin";
                        default:
                            Console.WriteLine("Elección inválida");
                            break;
                    }
                    Console.Clear();
                    break;
                case 1:
                    switch (respuesta1)
                    {
                        case 0:
                            Console.WriteLine("¡Ganaste! El enemigo perderá un punto  de salud.");
                            return "jugador 1";
                        case 1:
                            Console.WriteLine("¡Es un empate! Nadie pierde salud.");
                            return "empate";

                        case 2:
                            Console.WriteLine("¡Ohhh! Pierdes uno de salud.");
                            return "jugador 2";
                        case 3:
                            Console.WriteLine("Vas por el comodin E.E");
                            return "comodin";
                        default:
                            Console.WriteLine("Elección inválida.");
                            break;
                    }
                    Console.Clear();
                    break;
                case 2:
                    switch (respuesta1)
                    {
                        case 0:
                            Console.WriteLine("¡Demonios! Pierdes un punto de salud.");
                            return "jugador 2";
                            
                        case 1:
                            Console.WriteLine("¡Sigue así! Le quitaste un punto de salud.");
                            return "jugador 1";
                        case 2:
                            Console.WriteLine("¡Es un empate! No pasa nada");
                            return "empate";
                        case 3:
                            Console.WriteLine("Vas por el comodin E.E");
                            return "comodin";
                        default:
                            Console.WriteLine("Elección inválida");
                            break;
                    }
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Elección inválida");
                    break;
            }
            return "no aplica";
        }

        public void mostrar_Menu()
        {
            Console.WriteLine("----- RPG Game Menu -----");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Opciones");
            Console.WriteLine("3. Salir");

            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("¡Comenzando el juego!");
                        // Llamar a la función para iniciar el juego RPG
                        exitMenu = true;
                        break;
                    case "2":
                        Console.WriteLine("Accediendo a las opciones...");
                        // Llamar a la función para mostrar las opciones del juego
                        exitMenu = true;
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del juego...");
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                        break;
                }
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

    }
}
