
public class GH_Repository
{
    // I don't want this to exist unless there is a 
    // gremlin repository
    // * DEPENDENCIES -> INJECTING A DEPENDENCY
    private GremlinRepository _gRepo;

    private List<GremlinHunter> _gHunterDb = new List<GremlinHunter>();
    private int _count;

    //todo: make a constructor for the dependency
    //todo: Dependency Injection
    public GH_Repository(GremlinRepository gRepo)
    {
        _gRepo = gRepo;
        Seed();
    }
    

    //Crud

    //Create
    public bool AddGremlinHunter(GremlinHunter hunter)
    {
        if (hunter is null)
        {
            return false;
        }
        else
        {
            _count++;
            hunter.Id = _count;
            _gHunterDb.Add(hunter);
            return true;
        }
    }

    public List<GremlinHunter> GetGremlnHunters()
    {
        return _gHunterDb;
    }

    public GremlinHunter GetGremlinHunter(int hunterId)
    {
        //line 9 represents the collection...so we have to loop through to get the data
        foreach (var gremlinHunter in _gHunterDb)
        {
            if (gremlinHunter.Id == hunterId)
            {
                return gremlinHunter;
            }
        }
        return null;
    }

    public bool UpdateGremlinHunterData(int hunterId, GremlinHunter updatedGremlinHunterData)
    {
        //helper method
        var gremlinHunter = GetGremlinHunter(hunterId);

        //check if we have hunter data...
        if (gremlinHunter != null)
        {
            gremlinHunter.Name = updatedGremlinHunterData.Name;
            gremlinHunter.CapturedGremlins = updatedGremlinHunterData.CapturedGremlins;
            return true;
        }

        return false;
    }

    public bool DeleteHunter(int hunterId)
    {
        var hunter = GetGremlinHunter(hunterId);
        return _gHunterDb.Remove(hunter);
    }

    public void Seed()
    {
        var steve = new GremlinHunter("Steve");
        steve.CapturedGremlins = _gRepo.GetGremlins();

        AddGremlinHunter(steve);
    }
}
