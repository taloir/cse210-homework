public class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points) : base(name, description, points){

    }
    public override string GetStringRepresentation(){
        return($"eternal goal|{_Title}|{_Description}|{_Points}");
    }

    public override bool IsComplete(){
        return false;
    }

    public override int RecordEvent(){
        return base._Points;
    }
}