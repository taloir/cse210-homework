public class Entry
    {
    public string _Date;
    public string _Prompt;
    public string _Response;
    
    public void DisplayEntry()
    {
        Console.WriteLine($"{_Date}: {_Prompt} \n{_Response}");
    }
    }