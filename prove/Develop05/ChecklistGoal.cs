public class CheckListGoal : Goal{

    int _AmountCompleted;
    int _Target;
    int _Bonus;

    public CheckListGoal(string name, string description, int points, int target, int bonus):base(name, description, points){
        _AmountCompleted = 0;
        _Target = target;
        _Bonus = bonus;
    }
    public override string GetStringRepresentation(){
        string representation = $"checklist goal|{_Title}|{_Description}|{_Points}|{_AmountCompleted}|{_Bonus}";
        return(representation);
    }

    public override bool IsComplete(){
        bool isComplete;
        if(_AmountCompleted >= _Target){
            isComplete = true;
        }
        else{
            isComplete = false;
        }
        return isComplete;
    }

    public override int RecordEvent(){
        _AmountCompleted += 1;
        int points = 0;
        if (IsComplete()){
            points = _Bonus;
        }
        else{
            points = base._Points;
        }
        return points;
    }
}