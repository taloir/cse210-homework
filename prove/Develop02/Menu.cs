using System.Net;
using System.IO;
using System.IO.Enumeration;

public class Menu 
    {
        Journal _Journal = new Journal();
        string[] _Prompts = {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?", "What are you most proud of accomplishing today?", "What are you most looking forward to in the near future?", "what did you spend the most time on today?"};

        Random rnd = new Random();

        public void Write(){
            Entry newEntry = new Entry();
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            newEntry._Date = dateText;
            newEntry._Prompt = _Prompts[rnd.Next(_Prompts.Count())];
            Console.WriteLine(newEntry._Prompt);
            string response = Console.ReadLine();
            newEntry._Response = response;

            _Journal.AddEntry(newEntry);
            DisplayMenu();
        }
        public void Display(){
            _Journal.DisplayEntries();
            DisplayMenu();
        }
        public void Load(){
            Console.WriteLine("what journal would you like to load? \n(Use .txt at the end of the file name. A journal file name that has not first been saved at least once will not load properly.)");
            string filename = Console.ReadLine();
            try {
            string[] lines = System.IO.File.ReadAllLines(filename);
            Journal NewJournal = new Journal();
            NewJournal._Name = filename;

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                Entry NewEntry = new Entry();

                string date = parts[0];
                NewEntry._Date = date;
                string prompt = parts[1];
                NewEntry._Prompt = prompt;
                string response = parts[2];
                NewEntry._Response = response;

                NewJournal.AddEntry(NewEntry);
            }
            _Journal = NewJournal;
            }
            catch {
                Console.WriteLine("That file name does not exist.");
            }
            
            DisplayMenu();
        }
        public void Save(){
            string fileName;
            if (_Journal._Name == null){
                Console.WriteLine("What should the journal be saved as? This should be one word, ending in .txt");
                fileName = Console.ReadLine();
            }
            else{
                fileName = _Journal._Name;
            }
            _Journal._Name = fileName;

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach(Entry e in _Journal._Entries){

                outputFile.WriteLine($"{e._Date}|{e._Prompt}|{e._Response}");
                }
            }
            DisplayMenu();
        }
        public void Quit(){

        }
        public void DisplayMenu(){
            Console.WriteLine($"The {_Journal._Name} journal is open.");
            Console.WriteLine("What would you like to do? \n Load \n Save \n Display \n Write \n Quit");
            string action = Console.ReadLine();
            
            if (action.ToLower() == "load"){
                Load();
            }
            else if (action.ToLower() == "save"){
                Save();
            }
            else if (action.ToLower() == "display"){
                Display();
            }
            else if (action.ToLower() == "write"){
                Write();
            }
            else if (action.ToLower() == "quit"){
                Quit();
            }
            else{
                Console.WriteLine("That was not a valid action.");
                DisplayMenu();
            }
        }
    }