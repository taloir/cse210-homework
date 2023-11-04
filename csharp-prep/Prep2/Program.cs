using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is the students grade?");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string letter;
        if(grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"The student has a {letter} average");

        if (grade >= 70)
        {
            Console.WriteLine("congratulations, the student has passed the course!");
        }
        else
        {
            Console.WriteLine("The student has failed the course. Better luck next semester.");
        }
    }
}