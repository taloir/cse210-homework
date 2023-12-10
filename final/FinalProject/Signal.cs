public class Signal{
    private int _TargetNeuron;
    private double _ActivationValue;
    public Signal(int target, double value){
        _TargetNeuron =  target;
        _ActivationValue = value;
    }
}