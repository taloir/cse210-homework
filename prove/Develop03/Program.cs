using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please provide a scripture to memorize, in the format 'Book ##:## verse text'");
        string input = Console.ReadLine();
        Scripture scripture = new Scripture(input);
    }
}