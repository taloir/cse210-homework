using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        
        Job job1 = new Job();
        job1._Company = "Microsoft";
        job1._JobTitle = "software engineer";
        job1._StartYear = 2009;
        job1._EndYear = 2020;

        Job job2 = new Job();
        job2._Company = "Apple";
        job2._JobTitle = "software engineer";
        job2._StartYear = 1999;
        job2._EndYear = 2007;

        Resume resume1 = new Resume();
        resume1._Name = "Landon";
        resume1._Jobs.Add(job1);
        resume1._Jobs.Add(job2);

        resume1.Display();
    }
}