using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, square);

    }
    static void DisplayWelcome ()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName ()
    {
        Console.WriteLine("what is your name?");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber ()
    {
        Console.WriteLine("What is your favorite number?");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber (int number)
    {
        int square = number*number;
        return square;
    }
    static void DisplayResult (string name, int number)
    {
        Console.WriteLine($"Your name is {name} and your number is {number}");
    }
}