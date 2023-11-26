public class Activity{
    protected  string _Name;
    protected  string _Description;
    protected int _Duration;

    public Activity(){
    }

    public void StartMessage(){
        Console.WriteLine($"{_Name} \n{_Description}");
        Console.WriteLine("How long would you like to do this activity (in seconds)? ");
        _Duration = int.Parse(Console.ReadLine());
    }

    public void EndMessage(){
        Console.WriteLine($"You have completed {_Duration} seconds of the {_Name}");
    }

    public void Pause(int duration){
        int time = 0;
        while (time < duration){
            time ++;
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write("\b\b\b\b\b     \b\b\b\b\b");
        }
    }

    public void CountDown(int duration){
        int time = duration;
        while (time > 0){
            Console.Write(time);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            time --;
        }   
    }
}