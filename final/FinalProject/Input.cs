public class Input: Neuron{
    public Input(int innovation, double value):base(innovation){
        _ActivationValue= value;
    }
    public override void Activate(){
    }
    public override string GetSummary(){
        string summary = $"{_InnovationNumber}-[Value:{_ActivationValue}]";
        return summary;
    }
    public void SetValue(double value){
        _ActivationValue = value;
    }
}