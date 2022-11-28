
public class GremlinRepository
{

    public GremlinRepository()
    {
        Seed();
    }

    private List<Gremlin> gremlinDb = new List<Gremlin>();
    private int _count;

    //Crud 

    //Create gremlin -> local scope, 11-23
    public bool AddGremlin(Gremlin gremlin)
    {
        if (gremlin is null)
        {
            return false;
        }
        else
        {
            _count++;
            gremlin.Id = _count;
            gremlinDb.Add(gremlin);
            return true;
        }
    }

    public List<Gremlin> GetGremlins()
    {
        return gremlinDb;
    }

    //helper method
    public Gremlin GetGremlin(int gremlinId)
    {
        foreach (Gremlin gremlin in gremlinDb)
        {
            if (gremlin.Id == gremlinId)
            {
                return gremlin;
            }
        }
        return null;
    }

    public bool DeleteGremlin(int gremlinId)
    {
        Gremlin gremlin = GetGremlin(gremlinId);
        return gremlinDb.Remove(gremlin);
    }

    private void Seed()
    {
        var gremlinA = new Gremlin("Stripe");
        var gremlinB = new Gremlin("Mr. Magoo");
        var gremlinC = new Gremlin("Killer");

        AddGremlin(gremlinA);
        AddGremlin(gremlinB);
        AddGremlin(gremlinC);
    }
}
