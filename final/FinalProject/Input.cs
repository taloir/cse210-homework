public class Input: Neuron{
    public Input(int innovation, double value):base(innovation){
        _Signals.Add(value);
    }
    public override void Activate(){
        _ActivationValue = _Signals[0];
    }
    public override string GetSummary(){
        string summary = $"{_InnovationNumber}-[Value:{_Signals[0]}]";
        return summary;
    }
}