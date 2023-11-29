using System.Formats.Asn1;

public class Square: Shape{

    private int _Side;

    public Square(string color, int side):base(color){
        _Side = side;
    }

    public override int GetArea(){
        int area = _Side^2;
        return area;
    }
}