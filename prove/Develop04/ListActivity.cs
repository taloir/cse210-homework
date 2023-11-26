public class ListActivity : Activity{

    private string[] _Prompts = {"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    private int _Count = 0;

    Random rnd = new Random();

    public ListActivity(){
        _Name = "Listing activity";
        _Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        base.StartMessage();
        RunActivity();
    }

    public void RunActivity(){
        base.Pause(3);
        Console.WriteLine($"{GetRandomPrompt()}");
        base.Pause(5);
        AcceptList();
        base.EndMessage();
    }

    public string GetRandomPrompt(){
        string prompt = _Prompts[rnd.Next(_Prompts.Count())];
        return prompt;
    }

    public void AcceptList(){
        Console.WriteLine("Begin!");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_Duration);
        while (DateTime.Now < endTime){
            string response = Console.ReadLine();
            _Count++;
        }
        Console.WriteLine($"You completed {_Count} responses!");
    }
}