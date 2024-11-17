namespace BusShuttle;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        DataManager dataManager = new DataManager("passenger-data.txt");

        string mode = AskForInput("Please select mode (driver OR manager): ");

        if (mode == "driver")
        {
            string command;
            do
            {
                string stopName = AskForInput("Enter stop name: ");
                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                dataManager.AppendLine(stopName + ":" + boarded);

                command = AskForInput("Enter command (end OR continue): ");
            } while (command != "end");
        }
    }

    static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}

public class DataManager
{
    string fileName;

    public DataManager(string fileName)
    {
        this.fileName = fileName;
        File.Create(this.fileName).Close();
    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }
}
