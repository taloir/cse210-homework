using System.Xml.XPath;

public class Scripture{
    Reference _Reference;
    List<Word> _Words = new List<Word>();

    Random rnd = new Random();

    public Scripture(string scriptureText){
        string[] units = scriptureText.Split(" ");
        string book = units[0];
        string[] numbers = units[1].Split(":");
        int chapter = Int32.Parse(numbers[0]);
        string[] verses = numbers[1].Split("-");
        int verse = Int32.Parse(verses[0]);
        int endVerse;
        if (verses.Length > 1){
            endVerse = Int32.Parse(verses[1]);
            _Reference = new Reference(book, chapter, verse, endVerse);
        }
        _Reference = new Reference(book, chapter, verse);

        for (int i = 2; i < units.Length; i++){
            Word word = new Word(units[i]);
            _Words.Add(word);
        }
        CheckAllHidden();
    }

    public void Display(){
        string result = $"{_Reference.GetText()} ";
        foreach (Word word in _Words){
            result += $"{word.DisplayText()} ";
        }
        Console.WriteLine(result);
    }

    public void CheckAllHidden(){
        bool allHidden = true;
        foreach(Word word in _Words){
            if(word.GetHiddenState()){}
            else{
                allHidden = false;
            }
        }
        if (allHidden){}
        else{
            HideRandomWords();
            Display();
            Console.WriteLine("Press enter to continue, or type quit to finish.");
            string response = Console.ReadLine();
            if (response == "quit") {

            }
            else{
                CheckAllHidden();
            }
        }
    }

    public void HideRandomWords(){
        for(int i =0; i<3; i++){
            _Words[rnd.Next(_Words.Count())].Hide();
        }
    }
}