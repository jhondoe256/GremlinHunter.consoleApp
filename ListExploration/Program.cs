
// original way..
List<string> quotes = new List<string>();


List<string> quotes_ObjInitialization = new List<string>()
{
    "Im gonna get you sucka",
    "Who is the man..",
    "???",
};

//THE ONLY WAY TO GET TO THIS DATA IS TO LOOP
//for
//while
//foreach

// for (int i = 0; i < quotes_ObjInitialization.Count(); i++)
// {
//     System.Console.WriteLine($"{i}  - {quotes_ObjInitialization[i]}");
// }

// int i = 0;
// while (i < quotes_ObjInitialization.Count())
// {
//     System.Console.WriteLine($"{i}  - {quotes_ObjInitialization[i]}");
//     i++;
// }


int count = 0;
foreach (var quote in quotes_ObjInitialization)
{
    System.Console.WriteLine($"{count} - {quote}");
    count++;
}
Console.ReadKey();
