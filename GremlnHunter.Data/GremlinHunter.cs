
public class GremlinHunter
{
    public GremlinHunter() { }

    public GremlinHunter(string name)
    {
        Name = name;
    }

    public GremlinHunter(string name, List<Gremlin> capturedGremlins)
    {
        Name = name;
        CapturedGremlins = capturedGremlins;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Gremlin> CapturedGremlins { get; set; } = new List<Gremlin>();

    public override string ToString()
    {

        var str = "Gremlin Hunter {" + "\n";
        str += $"Id: {Id}\n";
        str += $"Name: {Name}\n";
        str += $"-- Caputred Gremlins --\n";

        if (CapturedGremlins.Count() > 0)
        {
            foreach (var gremlin in CapturedGremlins)
            {
                str += gremlin.ToString() + "\n";
            }
        }
        else
        {
            str += "No Captured Gremlins!\n";
        }
        str += "}" + "\n";
        str += "-------------------------------------\n";

        return str;
    }
}
