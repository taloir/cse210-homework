public class Menu{
    public void PresentMenu(){
        Console.WriteLine("Choose  an activity by typing the corresponding number: \n1- breathing activity\n2- reflection activity\n3- listing  activity\n4- quit");
        string response  = Console.ReadLine();
        if  (response  == "1"){
            BreathingActivity breathe = new BreathingActivity();
            PresentMenu();
        }            
        else if (response == "2"){
            ReflectActivity reflect = new ReflectActivity();
            PresentMenu();
        }
        else if (response == "3"){
            ListActivity list = new ListActivity();
            PresentMenu();
        }
        else{
            Console.WriteLine("Quiting the program.");
        }
    }
}