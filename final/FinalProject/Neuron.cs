using System.Data.Common;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml;

public abstract class Neuron{
    protected List<double> _Signals = new List<double>();
    protected double _ActivationValue;
    protected int _InnovationNumber;

    public Neuron(int innovation){
        _InnovationNumber = innovation;
    }
    public abstract string GetSummary();

    public abstract void Activate();

    public double GetActivation(){
        return _ActivationValue;
    }

    public int GetInnovation(){
        return _InnovationNumber;
    }

    public void AddSignal(double signal){
        _Signals.Add(signal);
    }
}