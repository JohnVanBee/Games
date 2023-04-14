// See https://aka.ms/new-console-template for more information
using Games;
using System.Diagnostics;


Double elapsedTime;
int fibCounter = 0;
long resultOfFibonacci;
Fibonacci fibonacci = new Fibonacci();
Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Console.WriteLine("Start met brute force Fibonacci methode om de snelheid pc te bepalen.");
Console.WriteLine("Reeks van Fibonacci: ");
Console.Write(" 0(1)");
for (int i = 1; i <= 90; i++)
{
    if (stopwatch.Elapsed > TimeSpan.FromSeconds(10))
    {
        stopwatch.Stop();
        Console.WriteLine("");
        Console.WriteLine("Er zijn " + fibCounter.ToString() + " getallen binnen een tijdslimiet berekend.");
        break;
    }
    fibCounter = i;
    resultOfFibonacci = fibonacci.BruteForceFibonacci(i);
    Console.Write(", " + resultOfFibonacci.ToString());
}

elapsedTime = stopwatch.ElapsedMilliseconds / 1000;
Console.WriteLine("");
Console.WriteLine("Deze brute force Fibonacci methode duurde " + Math.Round(elapsedTime, 2) + " seconden.");
Console.WriteLine("");
Console.WriteLine("");
stopwatch.Reset(); 
Thread.Sleep(1000);
Console.WriteLine("Dat kan veel beter.");
stopwatch.Start();


//MemoizedFibonacci
Console.WriteLine("Start met Memoized Fibonacci methode.");
Thread.Sleep(1000);
Console.WriteLine("Reeks van Fibonacci: ");
Console.Write(" 0");
for (int i = 1; i <= 90; i++)
{
    if (stopwatch.Elapsed > TimeSpan.FromSeconds(10))
    {
        Console.WriteLine("");
        Console.WriteLine("Er zijn " + fibCounter.ToString() + " getallen binnen de tijdslimiet berekend.");
        break;
    }
    fibCounter = i;
    resultOfFibonacci = fibonacci.MemoizedFibonacci(i);
    Console.Write(", " + resultOfFibonacci.ToString());
}
Console.WriteLine("");
stopwatch.Stop();
elapsedTime = stopwatch.ElapsedMilliseconds/1000;
Console.WriteLine("Deze Memoized Fibonacci methode duurde " +  Math.Round(elapsedTime, 2) + " seconden.");


Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Tijd voor een spelletje");
Thread.Sleep(3000);

GuessGame guess = new GuessGame();
guess.PlayGuess(true);