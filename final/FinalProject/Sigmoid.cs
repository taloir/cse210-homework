public class Sigmoid:Neuron{
    public Sigmoid(int innovation) : base(innovation){
    }

    public override void Activate(){
        double product = 0;
        foreach(double input in _Signals){
            product += input;
        }
        product = 1.0 / (1.0 + Math.Exp(-product));
        _ActivationValue = product;
    }

    public override string GetSummary(){
        string summary = $"{_InnovationNumber}: Sigmoid";
        return summary;
    }
}