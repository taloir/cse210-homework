public class Sigmoid:Neuron{
    public Sigmoid(int innovation) : base(innovation){
    }

    public override void Activate(){
        float product = 0;
        foreach(float input in base._Signals){
            product += input;
        }
        if(product < 0){
            product = 0;
        }
        base._ActivationValue = product;
    }

    public override string GetSummary(){
        string summary = $"{_InnovationNumber}: Sigmoid";
        return summary;
    }
}