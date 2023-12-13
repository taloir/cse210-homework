public class Output:Neuron{

    public Output(int innovation):base(innovation){}

    public override void Activate(){
        float product = 0;
        foreach(float input in _Signals){
            product += input;
        }
        _ActivationValue = product;
        _Signals.Clear();
    }
    public override string GetSummary(){
        string summary = $"{_InnovationNumber}";
        return summary;
    }
}