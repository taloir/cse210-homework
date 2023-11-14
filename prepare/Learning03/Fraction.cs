using System.Xml.XPath;

public class Fraction{
    private int _Numerator;
    private int _Denominator;

    public Fraction(){
        _Numerator = 1;
        _Denominator = 1;
    }

    public Fraction(int numerator){
        _Numerator = numerator;
        _Denominator = 1;
    }

    public Fraction(int numerator, int denominator){
        _Numerator = numerator;
        _Denominator = denominator;
    }

    public string GetFractionString(){
        string result = $"{_Numerator}/{_Denominator}";
        return result;
    }

    public double GetDecimalValue(){
        double result = _Numerator/_Denominator;
        return result;
    }

    public int GetNumerator(){
        return _Numerator;
    }
    public void SetNumerator(int numerator){
        _Numerator = numerator;
    }
    public int GetDenominator(){
        return _Denominator;
    }
    public void SetDenominator(int denominator){
        _Denominator = denominator;
    }

}