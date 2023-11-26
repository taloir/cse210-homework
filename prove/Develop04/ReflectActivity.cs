public class ReflectActivity : Activity{
    private string[] _Prompts = {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    private string[] _Questions = {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};

    Random rnd = new Random();

    public ReflectActivity(){
        _Name = "Reflection activity";
        _Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        base.StartMessage();
        RunActivity();
    }

    public void RunActivity(){
        base.Pause(3);
        Console.WriteLine($"{GetRandomPrompt()}");
        Console.WriteLine("When you are ready to begin, hit enter");
        Console.ReadLine();
        AskQuestions();
        base.EndMessage();
    }

    public string GetRandomPrompt(){
        string prompt = _Prompts[rnd.Next(_Prompts.Count())];
        return prompt;
    }

    public string GetRandomQuestion(){
        string question = _Questions[rnd.Next(_Questions.Count())];
        return question;
    }

    public void AskQuestions(){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_Duration);
        while (DateTime.Now < endTime){
            Console.WriteLine(GetRandomQuestion());
            string response = Console.ReadLine();
            base.Pause(5);
        }
    }
}