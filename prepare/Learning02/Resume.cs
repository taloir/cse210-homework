public class Resume
        {
            public string _Name;
            public List<Job> _Jobs = new List<Job>();

            public void Display()
            {
                Console.WriteLine($"Name: {_Name}");
                Console.WriteLine("Jobs: ");
                foreach (Job J in _Jobs)
                {
                    J.Display();
                }
            }
        }