using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class GuessGame
    {
        int maxGuesses = 6;
        public void PlayGuess()
        {
            Boolean play = true;
            while (play)
            {
                int gamble = 0;
                int numberOfGuesses = 0;
                gamble = GetGuess();
                numberOfGuesses = Guesses(gamble);
                Console.WriteLine("");
                if (numberOfGuesses > maxGuesses)
                {
                    Console.Write("Jij hebt gewonnen! ");
                }
                else
                {
                    Console.Write("Jij hebt verloren! ");
                }
                Console.WriteLine("Ik had " + numberOfGuesses + " keer nodig om het antwoord te raden.");
                play = PlayAgain("raad spel");
            }
        }
        private int GetGuess()
        {
            int min = 0;
            int max = 128;
            int number = 0;
            bool goodInput = false;
            Console.WriteLine("Vul een getal in tussen de 0 en 128");
            Console.WriteLine("Elke keer als ik geraden hebt zeg je hoger of lager.");
            Console.WriteLine("Als ik meer dan " + maxGuesses.ToString() + " keer gok heb je gewonnen.");
            Console.WriteLine("");
            Console.Write("Vul een getal in tussen de 0 en 128: ");

            while (!goodInput)
            {
                string gok = Console.ReadLine();
                Console.WriteLine("Jouw voor mij geheime nummer is " + gok);
                if (!int.TryParse(gok, out number))
                {
                    Console.Write("Vul een numeriek getal in tussen de 0 en 128: ");
                }
                else
                {
                    if (number < min)
                    {
                        Console.Write("Vul een positief getal in tussen de 0 en 128: ");
                    }
                    else if (number >= max)
                    {
                        Console.Write("Vul een positief getal in onder de 128: ");
                    }
                    else
                    {
                        goodInput = true;
                    }
                }
            };
            return number;
        }
        private int Guesses(int gamble)
        {
            int min = 0;
            int max = 128;
            int numberOfGuesses = 1;
            int bestGuess = (min + max) / 2;
            while ((bestGuess != gamble) || (numberOfGuesses > 10))
            {
                if (bestGuess > gamble)
                {
                    Console.WriteLine(gamble.ToString() + " is kleiner dan gok " + bestGuess.ToString());
                    max = bestGuess;
                    Console.Write("max wordt " + max.ToString());
                }
                else
                {
                    Console.WriteLine(gamble.ToString() + " is groter dan gok " + bestGuess.ToString());
                    min = bestGuess;
                    Console.Write("min wordt " + min.ToString());
                }
                bestGuess = (min + max) / 2;
                Console.WriteLine(", mijn gok wordt " + bestGuess.ToString());
                numberOfGuesses++;
            }
            return numberOfGuesses;
        }

        private bool PlayAgain(string game)
        {
            Console.Write("Wil je nogmaals " + game + " spelen [j/n] : ");
            var result = Console.ReadLine().ToLower();
            if (result == "j")
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                return true;
            }
            if (result == "n") return false;
            Console.WriteLine("Vul y of n!");
            return PlayAgain(game);
        }
    }
}

