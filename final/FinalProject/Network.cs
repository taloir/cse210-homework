using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class Network{
    
    private List<Neuron> _Inputs = new List<Neuron>();
    private List<Neuron> _HiddenLayer = new List<Neuron>();
    private List<Neuron> _Outputs = new List<Neuron>();
    private List<Connection> _Connections = new List<Connection>();
    private int _NextInnovation = 0;

    public Network(){
        Output newOutput = new Output(_NextInnovation);
        _Outputs.Add(newOutput);
        _NextInnovation +=1;

        Input defaultInput = new Input(_NextInnovation, 1);
        _Inputs.Add(defaultInput);
        _NextInnovation += 1;

        NewConnection(1, 0);
    }

    public void DisplayMenu(){
        Console.WriteLine("Enter the number of the desired action:\n1- Display Network\n2- Feedforward\n3- Add New Input\n4- Change input value\n5- Remove input\n6- Add Hidden Neuron\n7- Change hidden activation function\n8- Remove hidden neuron\n9- Add new output\n10- Remove output\n11- Add new connection\n12- Change connection weight\n13- Remove connection\n14- Quit");
        string response = Console.ReadLine();
        if(response == "1"){
            DisplayNetwork();
            DisplayMenu();
        }
        else if(response == "2"){
            FeedForward();
            DisplayMenu();
        }
        else if(response == "3"){
            NewInput();
            DisplayMenu();
        }
        else if(response == "4"){
            ChangeInputValue();
            DisplayMenu();
        }
        else if(response == "5"){
            RemoveInput();
            DisplayMenu();
        }
        else if(response == "6"){
            NewHidden();
            DisplayMenu();
        }
        else if(response == "7"){
            ChangeActivationFunction();
            DisplayMenu();
        }
        else if(response == "8"){
            RemoveHiddenNeuronSetup();
            DisplayMenu();
        }
        else if (response == "9"){
            NewOutput();
            DisplayMenu();
        }
        else if (response == "10"){
            RemoveOutput();
            DisplayMenu();
        }
        else if (response == "11"){ 
            NewConnectionFromMenu();
            DisplayMenu();
        }
        else if (response == "12"){
            ChangeConnectionWeight();
            DisplayMenu();
        }
        else if (response == "13"){
            RemoveConnection();
            DisplayMenu();
        }
        else{
            Quit();
        }
    }

    public void NewOutput(){
        string hiddenList = "Hidden neurons: ";
        foreach (Neuron hidden in _HiddenLayer){
            hiddenList += $"{hidden.GetInnovation()}, ";
        }
        string inputList = "Inputs: ";
        foreach (Neuron input in _Inputs){
            inputList += $"{input.GetInnovation()}, ";
        }
        Console.WriteLine(hiddenList);
        Console.WriteLine(inputList);
        Console.WriteLine("Enter the innovation number of the hidden neuron or input that the new output will connect to.");
        int source = int.Parse(Console.ReadLine());

        Output newOutput = new Output(_NextInnovation);
        _NextInnovation += 1;
        NewConnection(source, newOutput.GetInnovation());
        _Outputs.Add(newOutput);
        _NextInnovation += 1;
    }

    public void NewInput(){
        string outputList = "Outputs: ";
        foreach (Neuron output in _Outputs){
            outputList += $"{output.GetInnovation()}, ";
        }
        string hiddenList = "Hidden neurons: ";
        foreach (Neuron hidden in _HiddenLayer){
            hiddenList += $"{hidden.GetInnovation()}, ";
        }
        Console.WriteLine(outputList);
        Console.WriteLine(hiddenList);
        Console.WriteLine("Enter the innovation number of the hidden neuron or output that the new input will connect to.");
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the input value associated with this neuron.");
        double value = Convert.ToDouble(Console.ReadLine());

        Input newInput = new Input(_NextInnovation, value);
        NewConnection(newInput.GetInnovation(), target);
        _Inputs.Add(newInput);
        _NextInnovation += 1;
    }

    public void NewConnection(int source, int target, double weight = 1){
        Connection newConnection = new Connection(_NextInnovation, source, target, weight);
        _Connections.Add(newConnection);
        _NextInnovation += 1;
    }

    private void NewConnectionFromMenu(){
        string inputList = "Inputs: ";
            foreach (Neuron input in _Inputs){
                inputList += $"{input.GetInnovation()}, ";
            }
            string hiddenList = "Hidden neurons: ";
            foreach (Neuron hidden in _HiddenLayer){
                hiddenList += $"{hidden.GetInnovation()}, ";
            }
            string outputList = "Outputs: ";
            foreach (Neuron output in _Outputs){
                outputList += $"{output.GetInnovation()}, ";
            }
            Console.WriteLine(inputList);
            Console.WriteLine(hiddenList);
            Console.WriteLine("Enter the innovation number of the source neuron.");
            int source = int.Parse(Console.ReadLine());


            List<Connection> mutualSourceConnections = _Connections.FindAll(x => x.GetSource() == source );
            List<int> mutualSourceTargets = new List<int>();
            foreach(Connection connection in mutualSourceConnections){
                mutualSourceTargets.Add(connection.GetTarget());
            }
            string targetHiddenList = "Hidden neurons: ";
            foreach (Neuron hidden in _HiddenLayer){
                if(hidden.GetInnovation() != source){
                    if(mutualSourceTargets.Contains(hidden.GetInnovation()) == false){
                        targetHiddenList += $"{hidden.GetInnovation()}, ";
                    }
                }
            }
            string targetOutputList = "Outputs: ";
            foreach (Neuron output in _Outputs){
                if(mutualSourceTargets.Contains(output.GetInnovation()) == false){
                        targetOutputList += $"{output.GetInnovation()}, ";
                    }
            }
            Console.WriteLine(targetHiddenList);
            Console.WriteLine(targetOutputList);
            Console.WriteLine("Enter the innovation number of the target neuron.");
            int target = int.Parse(Console.ReadLine());
            NewConnection(source, target);
    }

    public void NewHidden(){
        string connectionList = "";
        foreach (Connection connection in _Connections){
            connectionList += $"{connection.GetInnovation().ToString()}, ";
        }
        Console.WriteLine($"Connection List: {connectionList}");
        Console.WriteLine("Enter the innovation number of the connection this neuron will replace");
        string connectionResponse = Console.ReadLine();

        Console.WriteLine("1- Relu\n2- sigmoid\n3- TanH");
        Console.WriteLine("Enter the number of the desired acitvation function.");
        string functionResponse = Console.ReadLine();

        if(functionResponse == "1"){
            Relu newHidden = new Relu(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        else if(functionResponse == "2"){
            Sigmoid newHidden = new Sigmoid(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        else if(functionResponse == "3"){
            TanH newHidden = new TanH(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        int newHiddenInnovation = _NextInnovation;
        _NextInnovation += 1;

            Connection targetConnection = _Connections.Find(x => x.GetInnovation() == int.Parse(connectionResponse));

            NewConnection(targetConnection.GetSource(), newHiddenInnovation, targetConnection.GetWeight());
            NewConnection(newHiddenInnovation, targetConnection.GetTarget(), 1);
            _Connections.RemoveAll( x => x.GetInnovation() == int.Parse(connectionResponse));
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
            networkSummary += "\n";
        }

        networkSummary += "\nOutputs:\n";
        foreach(Neuron output in _Outputs){
            networkSummary += $"{output.GetSummary()}, ";
        }
        Console.WriteLine(networkSummary);
        Console.WriteLine("Press enter when you are ready to return to the menu.");
        Console.ReadLine();
    }

    public void FeedForward(){
        List<Neuron> validTargets = new List<Neuron>();
        foreach(Neuron hidden in _HiddenLayer){
            validTargets.Add(hidden);
        }
        foreach (Neuron output in _Outputs){
            validTargets.Add(output);
        }
        List<Neuron> validSources = new List<Neuron>();
        foreach (Neuron hidden in _HiddenLayer){
            validSources.Add(hidden);
        }
        foreach (Neuron input in _Inputs){
            validSources.Add(input);
        }

        foreach(Connection connection in _Connections){
            int source = connection.GetSource();
            int target = connection.GetTarget();
            Neuron sourceNeuron = validSources.FindAll( x => x.GetInnovation() == source)[0];

            double activation = sourceNeuron.GetActivation();
            double product = connection.FeedForward(activation);

            Neuron targetNeuron = validTargets.FindAll( x => x.GetInnovation() == target)[0];
            targetNeuron.AddSignal(product);
        }

        foreach(Neuron output in _Outputs){
            output.Activate();
        }
        foreach(Neuron hidden in _HiddenLayer){
            hidden.Activate();
        }

        string outputString = "";
        foreach(double output in GetOutputs()){
            outputString += $"{output.ToString()}, ";
        }

        Console.WriteLine($"\n{outputString}");

        Console.WriteLine("Press enter when you are ready to return to the menu.");
        Console.ReadLine();
    }

    public List<double> GetOutputs(){
        List<double> outputList = new List<double>();
        foreach(Neuron output in _Outputs){
            outputList.Add(output.GetActivation());
        }
        return outputList;
    }

    public void RemoveInput(){
        string inputList = "";
        foreach (Neuron input in _Inputs){
            inputList += $"{input.GetInnovation()}, ";
        }
        Console.WriteLine($"Input List: {inputList}");
        Console.WriteLine("Enter the innovation number of the input to be removed.");
        int neuron = int.Parse(Console.ReadLine());

        List<Connection> connectedWeights = _Connections.FindAll(x => x.GetSource() == neuron);
        List<int> connectedNeurons = new List<int>();
        foreach(Connection connection in connectedWeights){
            connectedNeurons.Add(connection.GetTarget());
        }

        List<Neuron> validTargets = new List<Neuron>();
        foreach(Neuron hidden in _HiddenLayer){
            validTargets.Add(hidden);
        }
        foreach (Neuron output in _Outputs){
            validTargets.Add(output);
        }
        bool canRemove = true;
        foreach(Neuron target in validTargets){
            if(connectedNeurons.Contains(target.GetInnovation())){
                int sourceCount = 0;
                foreach(Connection connection in _Connections){
                    if(connection.GetTarget() == target.GetInnovation()){
                        sourceCount += 1;
                    }
                }
                if(sourceCount >= 2){

                }
                else{
                    canRemove = false;
                }
            }
        }
        if(canRemove == true){
            _Inputs.RemoveAll(x => x.GetInnovation() == neuron);
            foreach(Connection connection in connectedWeights){
                _Connections.Remove(connection);
            }
        }
        else{
            Console.WriteLine("If that neuron is removed, others will be isolated");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
    public void RemoveOutput(){
        string outputList = "";
        foreach (Neuron output in _Outputs){
            outputList += $"{output.GetInnovation()}, ";
        }
        Console.WriteLine($"Output List: {outputList}");
        Console.WriteLine("Enter the innovation number of the output to be removed.");
        int neuron = int.Parse(Console.ReadLine());

        List<Connection> connectedWeights = _Connections.FindAll(x => x.GetTarget() == neuron);
        List<int> connectedNeurons = new List<int>();
        foreach(Connection connection in connectedWeights){
            connectedNeurons.Add(connection.GetSource());
        }

        List<Neuron> validSources = new List<Neuron>();
        foreach(Neuron hidden in _HiddenLayer){
            validSources.Add(hidden);
        }
        foreach (Neuron input in _Inputs){
            validSources.Add(input);
        }
        bool canRemove = true;
        foreach(Neuron source in validSources){
            if(connectedNeurons.Contains(source.GetInnovation())){
                int targetCount = 0;
                foreach(Connection connection in _Connections){
                    if(connection.GetSource() == source.GetInnovation()){
                        targetCount += 1;
                    }
                }
                if(targetCount >= 2){}
                else{
                    canRemove = false;
                }
            }
        }
        if(canRemove == true){
            _Outputs.RemoveAll(x => x.GetInnovation() == neuron);
            foreach(Connection connection in connectedWeights){
                _Connections.Remove(connection);
            }
        }
        else{
            Console.WriteLine("If that neuron is removed, others will be isolated");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
    public void RemoveHiddenNeuronSetup(){
        string hiddenList = "";
        foreach (Neuron hidden in _HiddenLayer){
            hiddenList += $"{hidden.GetInnovation()}, ";
        }
        Console.WriteLine($"Hidden neuron List: {hiddenList}");
        Console.WriteLine("Enter the innovation number of the hidden neuron to be removed.");
        int neuron = int.Parse(Console.ReadLine());

        RemoveHiddenNeuron(neuron);
    }

    private void RemoveHiddenNeuron(int neuron){
        List<Connection> targetWeights = _Connections.FindAll(x => x.GetSource() == neuron);
        List<int> targetNeurons = new List<int>();
        foreach(Connection connection in targetWeights){
            targetNeurons.Add(connection.GetTarget());
        }
        List<Connection> sourceWeights = _Connections.FindAll(x => x.GetTarget() == neuron);
        List<int> sourceNeurons = new List<int>();
        foreach(Connection connection in sourceWeights){
            sourceNeurons.Add(connection.GetSource());
        }

        List<Neuron> allNeurons = new List<Neuron>();
        foreach(Neuron input in _Inputs){
            allNeurons.Add(input);
        }
        foreach(Neuron hidden in _HiddenLayer){
            allNeurons.Add(hidden);
        }
        foreach (Neuron output in _Outputs){
            allNeurons.Add(output);
        }
        
        bool canRemove = true;
        int sourceCount = 0;
        int targetCount = 0;
        foreach(Neuron n in allNeurons){
            if(targetNeurons.Contains(n.GetInnovation())){
                foreach(Connection connection in _Connections){
                    if(connection.GetTarget() == n.GetInnovation()){
                        sourceCount += 1;
                    }
                }
                if(sourceCount >= 2){}
                else{
                    canRemove = false;
                }
            }
            if(sourceNeurons.Contains(n.GetInnovation())){
                foreach(Connection connection in _Connections){
                    if(connection.GetSource() == n.GetInnovation()){
                        targetCount += 1;
                    }
                }
                if(targetCount >= 2){}
                else{
                    canRemove = false;
                }
            }
        }

        if(canRemove == true){
            _HiddenLayer.RemoveAll(x => x.GetInnovation() == neuron);
            foreach(Connection connection in sourceWeights){
                _Connections.Remove(connection);
            }
            foreach(Connection connection in targetWeights){
                _Connections.Remove(connection);
            }
        }
        else{
            Console.WriteLine("If that neuron is removed, others will be isolated");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
    public void RemoveConnection(){
        string connectionList = "";
        foreach (Connection connection in _Connections){
            connectionList += $"{connection.GetInnovation()}, ";
        }
        Console.WriteLine($"Connection List: {connectionList}");
        Console.WriteLine("Enter the innovation number of the connection to be removed.");
        int response = int.Parse(Console.ReadLine());

        Connection chosenConnection = _Connections.FindAll(x => x.GetInnovation()== response)[0];
        
        List<Neuron> neurons = new List<Neuron>();
        foreach(Neuron hidden in _HiddenLayer){
            neurons.Add(hidden);
        }
        foreach(Neuron input in _Inputs){
            neurons.Add(input);
        }
        foreach(Neuron output in _Outputs){
            neurons.Add(output);
        }
        Neuron sourceNeuron = neurons.FindAll(x => x.GetInnovation() == chosenConnection.GetSource())[0];
        Neuron targetNeuron = neurons.FindAll(x => x.GetInnovation() == chosenConnection.GetTarget())[0];

        int sourceCount = 0;
        int targetCount = 0;
        foreach(Connection connection in _Connections){
            if(connection.GetSource() == sourceNeuron.GetInnovation()){
                sourceCount += 1;
            }
            if(connection.GetTarget() == targetNeuron.GetInnovation()){
                targetCount += 1;
            }
        }
        if(sourceCount >= 2 && targetCount >= 2){
            _Connections.RemoveAll(x => x.GetInnovation() == response);
        }
        else{
            Console.WriteLine("If that connection is removed, some neurons would become isolated.");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
        }
    }
    public void ChangeInputValue(){
        string inputList = "";
        foreach (Neuron input in _Inputs){
            inputList += $"{input.GetInnovation()}, ";
        }
        Console.WriteLine($"Connection List: {inputList}");
        Console.WriteLine("Enter the innovation number of the input to be changed.");
        int response = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the new value.");
        double newValue = Convert.ToDouble(Console.ReadLine());
        foreach(Input input in _Inputs){
            if(input.GetInnovation() == response){
                input.SetValue(newValue);
            }
        }
    }
    public void ChangeActivationFunction(){
        string hiddenList = "";
        foreach (Neuron hidden in _HiddenLayer){
            hiddenList += $"{hidden.GetInnovation()}, ";
        }
        Console.WriteLine($"Connection List: {hiddenList}");
        Console.WriteLine("Enter the innovation number of the hidden neuron to be changed.");
        int neuron = int.Parse(Console.ReadLine());

        Console.WriteLine("1- Relu\n2- Sigmoid\n3- TanH");
        Console.WriteLine("Enter the number of the desired activation function");
        string activationFunction = Console.ReadLine();

        List<Connection> targetWeights = _Connections.FindAll(x => x.GetSource() == neuron);
        List<Connection> sourceWeights = _Connections.FindAll(x => x.GetTarget() == neuron);

        if(activationFunction == "1"){
            Relu newHidden = new Relu(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        else if(activationFunction == "2"){
            Sigmoid newHidden = new Sigmoid(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        else if(activationFunction == "3"){
            TanH newHidden = new TanH(_NextInnovation);
            _HiddenLayer.Add(newHidden);
        }
        int hiddenInnovation = _NextInnovation;
        _NextInnovation += 1;

        foreach(Connection connection in sourceWeights){
            NewConnection(connection.GetSource(), hiddenInnovation);
        }
        foreach(Connection connection in targetWeights){
            NewConnection(hiddenInnovation, connection.GetTarget());
        }

        RemoveHiddenNeuron(neuron);
    }
    public void ChangeConnectionWeight(){
        string connectionList = "";
        foreach (Connection connection in _Connections){
            connectionList += $"{connection.GetInnovation()}, ";
        }
        Console.WriteLine($"Connection List: {connectionList}");
        Console.WriteLine("Enter the innovation number of the connection to be changed");
        int response = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the new connection weight.");
        double newWeight = Convert.ToDouble(Console.ReadLine());

        foreach (Connection connection in _Connections){
            if(connection.GetInnovation() == response){
                connection.SetWeight(newWeight);
            }
        }
    }

    public void Quit(){

    }
}