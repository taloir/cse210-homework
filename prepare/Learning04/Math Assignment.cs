public class MathAssignment : Assignment{
    private string _TextBookSection;
    private string _Problems;

    public MathAssignment(string _StudentName, string _Topic, string section, string problems) : base(_StudentName, _Topic){
        _TextBookSection = section;
        _Problems = problems;
    }

    public string GetHomeWorkList(){
        return $"{_TextBookSection}, {_Problems}";
    }
}