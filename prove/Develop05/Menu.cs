using System.Net;
using System.IO; 
public class Menu{
    int _Score;
    List<Goal> _ActiveGoals;
    List<Goal> _Journal;

    public Menu(){
        _Score = 0;
        _ActiveGoals = new List<Goal>();
        _Journal = new List<Goal>();
    }

    public void DisplayMenu(){
        DisplayScore();
        Console.WriteLine("Enter the number of the desired action. \n1- create goal \n2- view active goals \n3- record event \n4- view journal \n5- save goals \n6- load goals \n7- quit");
        string response = Console.ReadLine();
        if(response == "1"){
            CreateGoal();
        }
        else if(response == "2"){
            DisplayActiveGoals();
        }
        else if(response == "3"){
            RecordEvent();
        }
        else if(response == "4"){
            DisplayJournal();
        }
        else if(response == "5"){
            SaveGoals();
        }
        else if(response == "6"){
            LoadGoals();
        }
        else if(response == "7"){
            Quit();
        }
        else{
            Console.WriteLine("That is not a valid response, please try again");
            DisplayMenu();
        }
    }

    public void DisplayScore(){
        Console.WriteLine($"You have {_Score} points! \n");
    }

    public void CreateGoal(){
        Console.WriteLine("Enter the number of the desired goal type.");
        Console.WriteLine("1- Simple Goal\n2- Checklist Goal\n3- Eternal Goal");
        string goalType = Console.ReadLine();
        _ActiveGoals.Add(ConstructGoal(goalType));
        DisplayMenu();
    }

    public Goal ConstructGoal(string goalType){
        if(goalType == "1"){
            Console.WriteLine("Name the goal.");
            string name = Console.ReadLine();
            Console.WriteLine("Provide a description of the goal. (optional)");
            string description = Console.ReadLine();
            Console.WriteLine("How many points is this goal worth?");
            int points = int.Parse(Console.ReadLine());

            SimpleGoal newGoal = new SimpleGoal(name, description, points);
            return newGoal;
        }
        else if(goalType == "2"){
            Console.WriteLine("Name the goal.");
            string name = Console.ReadLine();
            Console.WriteLine("Provide a description of the goal. (optional)");
            string description = Console.ReadLine();
            Console.WriteLine("How many points is this goal worth?");
            int points = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the target  number of times to complete the goal?");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("How many bonus points is it worth to  reach that target?");
            int bonus = int.Parse(Console.ReadLine());

            CheckListGoal newGoal = new CheckListGoal(name, description, points, target, bonus);
            return newGoal;
        }
        else{
            Console.WriteLine("Name the goal.");
            string name = Console.ReadLine();
            Console.WriteLine("Provide a description of the goal. (optional)");
            string description = Console.ReadLine();
            Console.WriteLine("How many points is this goal worth?");
            int points = int.Parse(Console.ReadLine());

            EternalGoal newGoal = new EternalGoal(name, description, points);
            return newGoal;
        }
    }

    public void DisplayActiveGoals(){
        foreach (Goal goal in _ActiveGoals){
            Console.WriteLine(goal.GetDetailString());
        }
        Console.WriteLine("When you are finished, hit enter to return to the menu.");
        Console.ReadLine();
        DisplayMenu();
    }

    public void RecordEvent(){
        if (_ActiveGoals.Count > 0){
        Console.WriteLine("Which goal have you accomplished?");
        ListActiveGoals();
        int goal = int.Parse(Console.ReadLine());
        _Score += _ActiveGoals[goal-1].RecordEvent();
        if (_ActiveGoals[goal-1].IsComplete()){
            _Journal.Add(_ActiveGoals[goal-1]);
            _ActiveGoals.RemoveAt(goal-1);
        }}
        else{
            Console.WriteLine("You do not have any active goals.");
        }
        DisplayMenu();
    }

    public void ListActiveGoals(){
        int index = 0;
        foreach (Goal goal in _ActiveGoals){
            index += 1;
            Console.WriteLine($"{index}: {goal.GetTitle()}");
        }
    }

    public void DisplayJournal(){
        foreach (Goal goal in _Journal){
            Console.WriteLine(goal.GetDetailString());
        }
        Console.WriteLine("When you are finished, hit enter to return to the menu.");
        Console.ReadLine();
        DisplayMenu();
    }

    public void SaveGoals(){
        Console.WriteLine("Please enter the desired filename.");
        string fileName = Console.ReadLine();

        using (StreamWriter outputActiveFile = new StreamWriter($"{fileName}_Active.txt")){
            foreach (Goal goal in _ActiveGoals){
                outputActiveFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        using (StreamWriter outputJournalFile = new StreamWriter($"{fileName}_Journal.txt")){
            outputJournalFile.WriteLine(_Score);
            foreach (Goal goal in _Journal){
                outputJournalFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        DisplayMenu();
    }

    public void LoadGoals(){
        Console.WriteLine("Please enter the desired filename.");
        string fileName = Console.ReadLine();

        string[] linesActive = System.IO.File.ReadAllLines($"{fileName}_Active.txt");
        foreach (string line in linesActive){
            string[] parts = line.Split("|");
            if (parts[0] == "simple goal"){
                SimpleGoal newGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                _ActiveGoals.Add(newGoal);
            }
            else if (parts[0] == "checklist goal"){
                CheckListGoal newGoal = new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                _ActiveGoals.Add(newGoal);
            }
            else{
                EternalGoal newGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                _ActiveGoals.Add(newGoal);
            }
        }

        string[] linesJournal = System.IO.File.ReadAllLines($"{fileName}_Journal.txt");
        _Score = int.Parse(linesJournal[0]);
        foreach (string line in linesJournal){
            string[] parts = line.Split("|");
            if (parts.Length !=1){
                if (parts[0] == "simple goal"){
                    SimpleGoal newGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    _Journal.Add(newGoal);
                }
                else if (parts[0] == "checklist goal"){
                    CheckListGoal newGoal = new CheckListGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                    _Journal.Add(newGoal);
                }
                else{
                    EternalGoal newGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    _Journal.Add(newGoal);
                }
            }
        }
        DisplayMenu();
    }

    public  void Quit(){

    }

}