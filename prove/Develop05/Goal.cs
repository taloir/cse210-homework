public abstract class Goal{

    protected string _Title;
    protected string _Description;
    protected int _Points;

    public Goal(string name, string description, int points){
        _Title = name;
        _Description = description;
        _Points = points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public string GetDetailString(){
        return($"{_Title}: {_Description}, {_Points}");
    }

    public string GetTitle(){
        return _Title;
    }
    public abstract string GetStringRepresentation();
}