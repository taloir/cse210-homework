public class WritingAssignment : Assignment{
    private string _Title;

    public WritingAssignment(string _StudentName, string _Topic, string title) : base(_StudentName, _Topic){
        _Title = title;
    }

    public string GetWritingInformation(){
        return $"{_Title}, {base._StudentName}";
    }
}