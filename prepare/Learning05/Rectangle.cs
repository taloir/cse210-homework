using System.Formats.Asn1;

public class Rectangle: Shape{

    private int _SideA;
    private int _SideB;

    public Rectangle(string color, int sideA, int sideB):base(color){
        _SideA = sideA;
        _SideB = sideB;
    }

    public override int GetArea(){
        int area = _SideA*_SideB;
        return area;
    }
}