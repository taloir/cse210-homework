public class Job
        {
            public string _Company;
            public string _JobTitle;
            public int _StartYear;
            public int _EndYear;

            public void Display()
            {
                Console.WriteLine($"{_JobTitle} ({_Company}) {_StartYear}-{_EndYear}");
            }
        }