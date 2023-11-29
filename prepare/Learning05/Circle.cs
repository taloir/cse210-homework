using System.Formats.Asn1;

public class Circle: Shape{

    private int _Radius;

    public Circle(string color, int radius):base(color){
        _Radius = radius;
    }

    public override int GetArea(){
        int area = 3*_Radius^2;
        return area;
    }
}