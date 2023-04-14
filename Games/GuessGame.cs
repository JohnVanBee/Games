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
        public void PlayGuess(Boolean guessRandom)
        {
            Boolean play = true;
            while (play)
            {
                int gamble = 0;
                int numberOfGuesses = 0;

                Thread.Sleep(1000);
                gamble = GetGuess();
                numberOfGuesses = Guesses(gamble, guessRandom);
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
            Console.WriteLine("Deze stap sla ik over, ik vraag het aan de AI.");
            Console.WriteLine("Als ik meer dan " + maxGuesses.ToString() + " keer nodig heb om het nummer te gokken heb jij gewonnen.");
            Console.WriteLine("");
            Console.Write("Vul een getal in tussen de 0 en 128: ");

            while (!goodInput)
            {
                string gok = Console.ReadLine();
                if (!int.TryParse(gok, out number))
                {
                    Console.WriteLine("Jouw invoer " + gok + " is niet numeriek!");
                    Console.Write("Vul een numeriek getal in tussen de 0 en 128: ");
                }
                else
                {
                    if (number < min)
                    {
                        Console.WriteLine("Het door jouw gekozen nummer " + gok + " is negatief!");
                        Console.Write("Vul een positief getal in tussen de 0 en 128: ");
                    }
                    else if (number >= max)
                    {
                        Console.WriteLine("Het door jouw gekozen nummer " + gok + " is te groot!");
                        Console.Write("Vul een positief getal in onder de 128: ");
                    }
                    else
                    {
                        Thread.Sleep(500);
                        goodInput = true;
                    }
                }
            };
            return number;
        }
        private int Guesses(int gamble, Boolean guessRandom)
        {
            int min = 0;
            int max = 128;
            int numberOfGuesses = 1;
            Random random = new Random();
            int bestGuess = (min + max) / 2;
            while ((bestGuess != gamble))
            {
                if (bestGuess > gamble)
                {
                    Console.WriteLine("Het door jouw gekozen nummer " + gamble.ToString() + " is kleiner dan mijn geraden getal " + bestGuess.ToString());
                    Thread.Sleep(1000);
                    if (max == bestGuess && guessRandom)
                    {
                        max = bestGuess - 1;
                    }
                    else
                    {
                        max = bestGuess;

                    }
                    Console.Write(" - max wordt " + max.ToString() + " en min blijft " + min.ToString());
                }
                else
                {
                    Console.WriteLine("Het door jouw gekozen nummer " + gamble.ToString() + " is groter dan dan mijn geraden getal " + bestGuess.ToString());
                    Thread.Sleep(1000);
                    if (min == bestGuess && guessRandom)
                    {
                        min = bestGuess +1;
                    }
                    else
                    {
                        min = bestGuess;

                    }
                    Console.Write(" - min wordt " + min.ToString() + " en max blijft " + max.ToString());
                }

                Thread.Sleep(1000);
                bestGuess = (min + max) / 2;
                // Oneven getallen worden in 7 maal geraden, het moet wel leuk blijven.
                if (guessRandom && numberOfGuesses > 2)
                { 
                    int randomGuess = random.Next(min, max);
                    bestGuess = randomGuess;
                }

                if (numberOfGuesses > 10)
                {
                    break;
                }
                Thread.Sleep(1000);
                Console.WriteLine(", ik raad nu het getal " + bestGuess.ToString());
                Thread.Sleep(1000);
                numberOfGuesses++;
            }
            return numberOfGuesses;
        }

        private bool PlayAgain(string game)
        {
            Console.Write("Wil je nogmaals het " + game + " spelen [j/n] : ");
            var result = Console.ReadLine().ToLower();
            if (result == "j")
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                return true;
            }
            if (result == "n") return false;
            Console.WriteLine("Vul j of n!");
            return PlayAgain(game);
        }
    }
}

