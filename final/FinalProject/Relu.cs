public class Relu:Neuron{
    public Relu(int innovation) : base(innovation){
    }

    public override void Activate(){
        double product = 0;
        foreach(double input in _Signals){
            product += input;
        }
        if(product < 0){
            product = 0;
        }
        _ActivationValue = product;
        _Signals.Clear();
    }

    public override string GetSummary(){
        string summary = $"{_InnovationNumber}: Relu";
        return summary;
    }
}