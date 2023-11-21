public class Assignment{
    protected string _StudentName;
    private string _Topic;

    public Assignment(string name, string topic){
        _StudentName = name;
        _Topic = topic;
    }

    public string GetSummary(){
        return $"{_StudentName}: {_Topic}";
    }
}