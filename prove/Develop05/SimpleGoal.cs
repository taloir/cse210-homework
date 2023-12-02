public class SimpleGoal : Goal{


    public SimpleGoal(string name, string description, int points) : base(name, description, points){
    }
    
    public override string GetStringRepresentation(){
        return($"simple goal|{_Title}|{_Description}|{_Points}");
    }

    public override bool IsComplete(){
        return(true);
    }

    public override int RecordEvent(){
        return base._Points;
    }
}