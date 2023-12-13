using System.Net.Http.Headers;

public class Connection{
    private int _InnovationNumber;
    private double _Weight;
    private int _Source;
    private int _Target;

    public Connection(int innovation, int source, int target, double weight){
        _InnovationNumber = innovation;
        _Source = source;
        _Target = target;
        _Weight = weight;
    }

    public double FeedForward(double activation){
        double product = activation*_Weight;
        return product;
    }
    public string GetSummary(){
        string summary = $"{_InnovationNumber}({_Target},{_Weight})";
        return summary;
    }
    public int GetInnovation(){
        return _InnovationNumber;
    }
    public int GetTarget(){
        return _Target;
    }
    public int GetSource(){
        return _Source;
    }
    public double GetWeight(){
        return _Weight;
    }
    public void SetWeight(double weight){
        _Weight = weight;
    }
}