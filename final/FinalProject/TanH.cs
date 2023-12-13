public class TanH:Neuron{
    public TanH(int innovation) : base(innovation){
    }

    public override void Activate(){
        double product = 0;
        foreach(double input in _Signals){
            product += input;
        }
        product = Math.Tanh(product);
        _ActivationValue = product;
    }

    public override string GetSummary(){
        string summary = $"{_InnovationNumber}: TanH";
        return summary;
    }
}