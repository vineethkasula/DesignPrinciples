

public class ParkingLot {

    public int MAX_FLOOR;
    public int MAX_SLOT;
    List<ParkingFloor> floor = new List<ParkingFloor>();

    public ParkingLot(int num, int slt) {
        MAX_FLOOR = num;
        MAX_SLOT = slt;
    }

    public static void AddFloors() {
        for(int i = 0; i < MAX_FLOOR; i++){
            floor.Add(new ParkingFloor(MAX_SLOT));
        }
    }

    public void InsertVechile(Vechile vechile) {
        for(int i = 0; i< MAX_FLOOR; i++) {
            if(floor[i].IsSpaceAvailable()) {
                vechile.Floorlevel = i;
                floor[i].AddVechile(vechile);
                break;
            }
        }
    }

    public void RemoveVechile(Vechile vechile) {
           floor[vechile.FloorLevel].Remove(vechile); 
    }

    
}

public class ParkingFloor {
    public int MAX_SLOT;
    public List<Vechile> slot;

    public ParkingFloor(int max){
        MAX_SLOT = max;
        slots = new List<Vechile>();
    }

    public bool IsSpaceAvailable() {
        return slots.Count() < MAX_SLOT;
    }

    public void AddVechile(Vechile vechile) { 
        slot.Add(vechile); 
    }

    public void Remove(Vechile vechile) { 
        slot.Remove(vechile);
    }
}

public class Vechile {
    private string VechileNo;
    private string Name;
    private string VechileType;
    private int FloorLevel;
    private int Slot;

    public Vechile(string vechileNo, string name, string vechileType) {
        VechileNo = vechileNo;
        Name = name;
        VechileType = vechileType;
    }
}

public class Client {
    public static void Main(string[] args) {
        
        Vechile bike = new Vechile("AP36H4320", "splendor", VechileType.Small);
        Vechile car = new Vechile("AP36H48862", "Dzire", VechileType.Mid);
        Vechile bus = new Vechile("AP36H48862", "Dzire", VechileType.Mid);

        ParkingLot lot = new ParkingLot(5, 20); //5 floors with 20 slots;
        lot.AddVechile(bike);
        lot.AddVechile(car);
        lot.AddVechile(bus);
    }
}

public enum VechileType {
    Small = "Small",
    Mid = "Mid",
    Large = "Large"
}