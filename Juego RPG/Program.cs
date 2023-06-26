using Juego_RPG;
using System;

Validations validation = new Validations();



List<string> dialogos_DonCangrejo = new List<string>()
        {
            "Plankton: Don Cangrejo, algún día obtendré esa fórmula y el Krustacio Caskarudo será mío.",
            "Plankton: Riete mientras puedas Eugenio, pero cuando obtenga la formula de la CangreBurger, seré yo quien ría, MUUUAJAJAJA",
            "Plankton: Don Cangrejo, tú y tu codicia desmedida son la única razón por la que sigo intentando robar tu fórmula. ¡No descansaré hasta tenerla!",
            "Plankton: ¡JAJAJAJA!, la esponja no te podrá ayudar"
        };

List<string> dialogos_Plankton = new List<string>()
        {
            "Don Cangrejo: ¡Ay, Plankton!¡Nunca aprenderás!",
            "Don Cangrejo: Plankton no tienes que esforzate tanto, tu mismo sabe que nunca podras obtener la formula de la Cangreburger",
            "Don Cangrejo: Bob Esponja, proteje la receta de la CangreBurguer mientras acabo con este animal.",
            "Don Cangrejo: ¡Bob Esponja! ¡Escondela bien!"
        };

Jugador jugador_Real;
Jugador bot;
List<string> jugador_Real_Ataques;
List<string> bot_Ataques;
string salud_Player;
string salud_Bot;

ShowMenu();
void inciar_Juego()
{
    //Console.WriteLine("Bienvenido a Fondo de Bikini\nEliga alguno de los roles: \n");

    imprimir_Bienvenida(3, "BIENVENIDO A FONDO DE BIKINI");


    int elección = validation.input_Int("1 Para Don Cangrejo -- 2 Para Plankton");
    Console.Clear();
    if (elección == 1)
    {
        jugador_Real = new Jugador("DonCangrejo", 5);
        jugador_Real_Ataques = jugador_Real.Ataques1();
        bot = new Jugador("Plankton", 5);
        bot_Ataques = jugador_Real.Ataques2();

        salud_Player = jugador_Real.health_P1();
        salud_Bot = bot.health_P2();
        Console.WriteLine("Ha seleccionado a Don Cangrejo");
    }
    else
    {

        jugador_Real = new Jugador("Plankton", 5);
        jugador_Real_Ataques = jugador_Real.Ataques2();
        bot = new Jugador("DonCangrejo", 5);
        bot_Ataques = jugador_Real.Ataques1();

        salud_Player = jugador_Real.health_P2();
        salud_Bot = bot.health_P1();
        Console.WriteLine("Ha seleccionado a Plankton");
    }


    do
    {
        Random random = new Random();
        int random_indice = random.Next(0, 4);
        Console.ForegroundColor = ConsoleColor.Gray;
        if (jugador_Real.get_Name() == "DonCangrejo")
        {
            imprimir_Bienvenida(3, dialogos_DonCangrejo[random_indice]);
        }
        else
        {
            imprimir_Bienvenida(3, dialogos_Plankton[random_indice]);
        }
        Console.ResetColor();
        string resultado_Turno = jugador_Real.Jugar(jugador_Real.seleccion_Jugador(jugador_Real_Ataques), bot.seleccion_Bot(bot_Ataques), jugador_Real_Ataques, bot_Ataques);
        switch (resultado_Turno)
        {
            case "jugador 1":

                jugador_Real.set_Health(jugador_Real.get_Health() - 1);
                Console.Write("La salud del enemigo: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                salud_Player = jugador_Real.remove_Health(salud_Player);
                break;

            case "jugador 2":
                Console.ResetColor();
                bot.set_Health(bot.get_Health() - 1);
                Console.Write("Tu salud actual: ");
                Console.ForegroundColor = ConsoleColor.Green;
                salud_Bot = bot.remove_Health(salud_Bot);
                break;

            case "comodin":

                if (jugador_Real.get_Comodin() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    jugador_Real.set_Health(jugador_Real.get_Health() - 1);

                    Console.Write("La salud del enemigo: ");
                    salud_Player = jugador_Real.remove_Health(salud_Player);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Has usado la mano negra ya no podrás volver a usarla");
                    jugador_Real.set_Comodin(0);
                    Console.ResetColor();
                }
                else Console.WriteLine("Ya has quemado la mano negra e.e");
                break;
            default:
                break;
        }
        if (jugador_Real.get_Health() == 0)
        {
            bot.set_Health(0);
        }
        Console.ResetColor();

    } while (bot.get_Health() != 0);


    if (jugador_Real.get_Health() != 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("¡HAS SIDO DERROTADO!");
        Console.ResetColor();
    }
    else
    {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("¡HAS VENCIDO!");
        Console.ResetColor();
    }
}


void ShowMenu()
{
    Console.WriteLine("----- RPG Game Menu -----");
    Console.WriteLine("1. Jugar");
    Console.WriteLine("2. Salir");

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
                Thread.Sleep(1000);
                inciar_Juego();
                exitMenu = true;
                break;
            case "2":
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

void imprimir_Bienvenida(int height,string texto)
{


    int width = texto.Length + 4; // Width of the rectangle

    string horizontalLine = new string('═', width);
    string emptyLine = $"║ {new string(' ', width - 2)} ║";
    string textLine = $"║  {texto}  ║";

    Console.WriteLine($"╔{horizontalLine}╗"); // Top line

    for (int i = 0; i < height - 2; i++)
    {
        Console.WriteLine(emptyLine); // Empty lines
    }

    Console.WriteLine(textLine); // Text line

    for (int i = 0; i < height - 2; i++)
    {
        Console.WriteLine(emptyLine); // Empty lines
    }

    Console.WriteLine($"╚{horizontalLine}╝"); // Bottom line
}


