using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the students name? ");
        string name1 = Console.ReadLine();
        Console.WriteLine("What is the assignment topic? ");
        string topic1 = Console.ReadLine();
        Console.WriteLine("What section was assigned? ");
        string section1 = Console.ReadLine();
        Console.WriteLine("Which problems were assigned? ");
        string problems1 = Console.ReadLine();
        MathAssignment math1 = new MathAssignment(name1, topic1, section1, problems1);

        Console.WriteLine($"{math1.GetSummary()}");
        Console.WriteLine($"{math1.GetHomeWorkList()}");

        Console.WriteLine("What is the students name? ");
        string name2 = Console.ReadLine();
        Console.WriteLine("What is the assignment topic? ");
        string topic2 = Console.ReadLine();
        Console.WriteLine("What was the title of the students response? ");
        string title1 = Console.ReadLine();
        WritingAssignment writing1 = new WritingAssignment(name2, topic2, title1);

        Console.WriteLine($"{writing1.GetSummary()}");
        Console.WriteLine($"{writing1.GetWritingInformation()}");
    }
}