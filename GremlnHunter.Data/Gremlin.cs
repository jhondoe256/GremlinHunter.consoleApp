public class Gremlin
{
    public Gremlin() { }

    public Gremlin(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }


    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var str = "Gremlin {" + "\n";
        str += $"Id: {Id}\n";
        str += $"Name: {Name}\n";
        str += $"Age: {Age}\n";
        str += "}" + "\n";
        str += "--------------------------------\n";

        return str;
    }
}