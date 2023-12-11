using System.Data;
using System.Diagnostics;

public class Network{
    
    private List<Neuron> _Inputs = new List<Neuron>();
    private List<Neuron> _HiddenLayer = new List<Neuron>();
    private List<Neuron> _Outputs = new List<Neuron>();
    private List<Connection> _Connections = new List<Connection>();
    private int _NextInnovation = 0;

    public Network(){
        NewOutput();
        NewInput(1);
        NewConnection(1, 0);
    }

    public void DisplayMenu(){
        Console.WriteLine("Enter the number of the desired action:\n1- Display Network\n2- Feedforward\n3- Add Hidden Neuron\n4- Quit");
        string response = Console.ReadLine();
        if(response == "1"){
            DisplayNetwork();
        }
        else if(response == "2"){
            FeedForward();
        }
        else if(response == "3"){
            NewHidden();
        }
        else if(response == "4"){

        }
        else{
            Quit();
        }
    }

    public void NewOutput(){
        Output newOutput = new Output(_NextInnovation);
        _Outputs.Add(newOutput);
        _NextInnovation +=1;
    }

    public void NewInput(double value){
        Input defaultInput = new Input(_NextInnovation, value);
        _Inputs.Add(defaultInput);
        _NextInnovation += 1;
    }

    public void NewConnection(int source, int target, double weight = 0.1){
        Connection newConnection = new Connection(_NextInnovation, source, target, weight);
        _Connections.Add(newConnection);
        _NextInnovation += 1;
    }

    public void NewHidden(){
        string connectionList = "";
        foreach (Connection connection in _Connections){
            connectionList += $"{connection.GetId().ToString()}, ";
        }
        Console.WriteLine($"Connection List: {connectionList}");
        Console.WriteLine("Enter the innovation number of the connection this neuron will replace");
        string response = Console.ReadLine();

        Relu newHidden = new Relu(_NextInnovation);
        int newHiddenInnovation = _NextInnovation;
        _HiddenLayer.Add(newHidden);
        _NextInnovation += 1;

        Connection targetConnection = _Connections.Find(x => x.GetId() == int.Parse(response));

        NewConnection(targetConnection.GetSource(), newHiddenInnovation, targetConnection.GetWeight());
        NewConnection(newHiddenInnovation, targetConnection.GetTarget(), 1);
        _Connections.RemoveAll( x => x.GetId() == int.Parse(response));

        DisplayMenu();
    }

    public void DisplayNetwork(){
        string networkSummary = "\nInputs:\n";
        foreach(Input input in _Inputs){
            networkSummary += input.GetSummary();
            foreach(Connection connection in _Connections){
                if(input.GetInnovation() == connection.GetSource()){
                    networkSummary += $", {connection.GetSummary()}";
                }
            }
            networkSummary += "\n";
        }

        networkSummary += "\nHidden Layer:\n";
        foreach(Neuron hidden in _HiddenLayer){
            networkSummary += hidden.GetSummary();
            foreach(Connection connection in _Connections){
                if(hidden.GetInnovation() == connection.GetSource()){
                    networkSummary += $", {connection.GetSummary()}";
                }
            }
        }

        networkSummary += "\nOutputs:\n";
        foreach(Neuron output in _Outputs){
            networkSummary += output.GetSummary();
        }
        Console.WriteLine(networkSummary);
        DisplayMenu();
    }

    public void FeedForward(){
        List<Neuron> validTargets = _HiddenLayer;
            foreach (Neuron output in _Outputs){
                validTargets.Add(output);
            }
        List<Neuron> validSources = _HiddenLayer;
            foreach (Neuron input in _Inputs){
                validTargets.Add(input);
            }
        
        foreach(Connection connection in _Connections){
            int source = connection.GetSource();
            int target = connection.GetTarget();
            foreach (Neuron s in validSources){
                if (s.GetInnovation()== source){
                    double activation = _HiddenLayer[source].GetActivation();
                    double product = connection.FeedForward(activation);
                    foreach(Neuron t in validTargets){
                        if(t.GetInnovation() == target){
                            t.AddSignal(product);
                        }
                    }
                }
            }
        }

        foreach(Neuron target in validTargets){
            target.Activate();
        }

        string outputString = "";
        foreach(double output in GetOutputs()){
            outputString += $"{output.ToString()}, ";
        }

        Console.WriteLine($"\n{outputString}");
        DisplayMenu();
    }

    public List<double> GetOutputs(){
        List<double> outputList = new List<double>();
        foreach(Neuron output in _Outputs){
            outputList.Add(output.GetActivation());
        }
        return outputList;
    }

    public void RemoveInput(){

    }
    public void RemoveOutput(){

    }
    public void RemoveHiddenNeuron(){

    }
    public void RemoveConnection(){

    }
    public void ChangeActivationFunction(){

    }
    public void ChangeConnectionWeight(){
        
    }

    public void Quit(){

    }
}