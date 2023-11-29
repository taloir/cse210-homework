using System.Formats.Asn1;

public abstract class Shape{
    private string _Color;

    public Shape(string color){
        SetColor(color);
    }

    public string GetColor(){
        return _Color;
    }

    public void SetColor(string color){
        _Color = color;
    }

    public abstract int GetArea();
}