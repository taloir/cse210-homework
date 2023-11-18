using System.ComponentModel.DataAnnotations;

public class Word{
    private string _Text;
    private bool _IsHidden;

    public Word(string text){
        _Text = text;
    }

    public void Hide(){
        _IsHidden = true;
    }

    public void Show(){
        _IsHidden = false;
    }

    public bool GetHiddenState(){
        return _IsHidden;
    }

    public string DisplayText(){
        string result = "";
        if (_IsHidden == true){
            int length = _Text.Length;
            for(int i = 0; i < length; i++){
                result += "_";
            }
        }
        else{
            result = _Text;
        }

        return result;
    }
}