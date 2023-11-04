using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,11);

        int guess;
        do {
            Console.WriteLine("Guess a number between 1 and 10");
        string guessString = Console.ReadLine();
        guess = int.Parse(guessString);

        if (guess > number)
        {
            Console.WriteLine("Your guess was too high");
        }
        else if (guess < number)
        {
            Console.WriteLine("Your guess was too low");
        }
        else
        {
            Console.WriteLine("Correct!");
        }
        }
        while (guess != number);
        
    }
}