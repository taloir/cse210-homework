using System;
using System.Xml.Schema;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>;
        int number;
        do 
        {
            Console.WriteLine("Please enter a number.");
            number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }
        while (number != 0);
    }

    int total = 0;
    int maximum;
    foreach (int number in numbers)
    {
        total += number;  
        if (maximum < number)
        {
            maximum = number
        } 
    }
    int average = total/numbers.Count;

    Console.WriteLine($"Total is {total}")
    Console.WriteLine($"Average is {average}")
    Console.WriteLine($"Maximum is {maximum}")
}