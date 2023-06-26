using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Juego_RPG
{
    internal class Validations
    {
        public string input_String(string request)
        {
            string word = string.Empty;
            bool sentinel = true;
            do
            {
                Console.WriteLine(request);
                word = Console.ReadLine();

                if (validate_Alphabet(word)) sentinel = false;
                else Console.WriteLine("You have to Enter an alphabetic characthers");

            } while (sentinel);
            return word;
        }
        public int input_Int(string request)
        {
            int num;
            bool sentinel = true;
            do
            {
                Console.WriteLine(request);
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num > 0 && num < 3) sentinel = false;
                    else Console.WriteLine("El número debe se estar entre 1 y 2");
                }
                else Console.WriteLine("The number value has to be a Int type, please try again: ");

            } while (sentinel);
            return num;
        }

        public char input_Char(string request)
        {
            bool sentinel = true;
            char[] ch = new char[1];
            do
            {
                Console.WriteLine(request);
                ch = Console.ReadLine().ToCharArray();

                if (validate_Letter(ch[0])) sentinel = false;
                else Console.WriteLine("The has to be a alphabetic characther");

            } while (sentinel);
            return ch[0];
        }
        public bool validate_Letter(char character)
        {
            if (char.IsLetter(character)) return true;
            else Console.WriteLine("The character isn't an alphabetic characther, please try again...");
            return false;
        }
        private bool validate_Alphabet(string word)
        {
            Regex toValidate = new Regex("^[a-zA-Z]+$");
            if (toValidate.IsMatch(word)) return true;

            return false;
        }

    }
}
