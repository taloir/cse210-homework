public class BreathingActivity : Activity{
    
    public BreathingActivity():base(){
        _Name = "Breathing activity";
        _Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        base.StartMessage();
        RunActivity();
    }

    public void RunActivity(){
        base.Pause(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_Duration);
        while (DateTime.Now < endTime){
            Console.WriteLine("Breathe in...");
            base.CountDown(4);
            Console.WriteLine("Breathe out...");
            base.CountDown(4);
        }
        base.EndMessage();
        base.Pause(6);
    }
}