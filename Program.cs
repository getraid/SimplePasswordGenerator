using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePasswordGenerator
{
    class Program
    {
        #region init
        public static List<char> AeiouList { get; set; }
        public static List<char> BigAeiouList { get; set; }


        public static List<char> PrintableChars { get; set; }

        private static void Main(string[] args)
        {


            Random rng = new Random();

            AeiouList = new List<char>
            {
                'a','e','i','o','u'
            };

            PrintableChars = new List<char>();
            #endregion

            // Alphabet wird aus ASCII in PrintableChars geladen
            for (int i = 97; i <= 122; i++)
            {
                PrintableChars.Add(Convert.ToChar(i));
            }

            //Es werden aeiou aus dem Alphabet entfernt
            foreach (var t in AeiouList)
            {
                PrintableChars.Remove(t);
            }

            //Schleife zum neu generieren bei jedem Tastendruck außer ESC
            while (true)
            {
                //20 Passwörter werden generiert.
                for (int i = 0; i < 20; i++)
                {
                    GenerateNewPw(rng);
                }

                Console.WriteLine("\nPress the Escape (Esc) key to quit: \n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
               
                Console.Clear();
              
            }
        }

        private static void GenerateNewPw(Random rng)
        {
            string temp = "";
            //Erster Buchstabe groß
            char c = PrintableChars[rng.Next(0, PrintableChars.Count)];
            temp += char.ToUpper(c);

            // 1x Aeiou & 1x Alphabet ohne. 3 Mal plus 1 Großbuchstabe. 
            for (int i = 0; i < 3; i++)
            {
                temp += AeiouList[rng.Next(0, AeiouList.Count)];
                temp += PrintableChars[rng.Next(0, PrintableChars.Count)];
            }

            //Zwei Zahlen im Passwort
            for (int i = 0; i < 2; i++)
            {
                temp += rng.Next(0, 9);
            }

            Console.WriteLine(temp);
        }
    }
}
