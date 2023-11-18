public class Reference{
    private string _Book;
    private int _Chapter;
    private int _Verse;
    private int _EndVerse = 0;

    public Reference(string book, int chapter, int verse){
        _Book = book;
        _Chapter = chapter;
        _Verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse){
        _Book = book;
        _Chapter = chapter;
        _Verse = verse;
        _EndVerse = endVerse;
    }

    public string GetText(){
        string result;
        if (_EndVerse != 0){
            result = $"{_Book} {_Chapter}:{_Verse}-{_EndVerse}";
        }
        else{
            result = $"{_Book} {_Chapter}:{_Verse}";
        }
        return result;
    }
}