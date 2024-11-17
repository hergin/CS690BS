namespace BusShuttle;

public class DataManager {
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }
    FileSaver fileSaver;

    public DataManager() {
        fileSaver = new FileSaver("passenger-data.txt");

        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));
        Loops.Add(new Loop("Orange"));

        Stops = new List<Stop>();
        var stopsFileContent = File.ReadAllLines("stops.txt");
        foreach(var stopName in stopsFileContent) {
            Stops.Add(new Stop(stopName));
        }

        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Huseyin Ergin"));
        Drivers.Add(new Driver("Jane Doe"));

        PassengerData = new List<PassengerData>();
    }

    public void AddNewPassengerData(PassengerData data) {
        this.PassengerData.Add(data);
        this.fileSaver.AppendData(data);
    }

    public void AddStop(string newStopName) {
        this.Stops.Add(new Stop(newStopName));
        this.SynchronizeStops();
    }

    public void RemoveStop(Stop toRemove) {
        this.Stops.Remove(toRemove);
        this.SynchronizeStops();
    }

    public void SynchronizeStops() {
        File.Delete("stops.txt");
        foreach(var stop in Stops) {
            File.AppendAllText("stops.txt",stop.Name+Environment.NewLine);
        }
    }
}