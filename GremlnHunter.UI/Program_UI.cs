using static System.Console;
public class Program_UI
{
    //todo: I need the gremlinRepo FIRST!!!!
    private readonly GremlinRepository _gRepo;
    private readonly GH_Repository _gHRepo;

    public Program_UI()
    {
        _gRepo = new GremlinRepository();
        _gHRepo = new GH_Repository(_gRepo);
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Clear();
            System.Console.WriteLine("=== Gremlin Hunters! ===\n" +
            "1.  Add A Hunter\n" +
            "2.  View All Hunters\n" +
            "3.  View Hunter By Id\n" +
            "4.  Update Hunter Data\n" +
            "5.  Delete Hunter Data\n" +
            "-----------------------\n" +
            "6.  Add A Gremlin\n" +
            "7.  View All Gremlins\n" +
            "8.  View A Gremlin\n" +
            "9.  Update Gremlin\n" +
            "10. Delete Gremlin\n" +
            "0.  Close Application\n");

            var userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    AddAHunter();
                    break;
                case "2":
                    ViewAllHunters();
                    break;
                case "3":
                    ViewHunterById();
                    break;
                case "4":
                    UpdateHunterData();
                    break;
                case "5":
                    DeleteHunterData();
                    break;
                case "6":
                    AddAGremlin();
                    break;
                case "7":
                    ViewAllGremlins();
                    break;
                case "8":
                    ViewAGremlin();
                    break;
                case "9":
                    UpdateGremlin();
                    break;
                case "10":
                    DeleteGremlin();
                    break;
                case "0":
                    isRunning = CloseApplication();
                    break;
                default:
                    WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;
            }

        }
    }

    private bool CloseApplication()
    {
        WriteLine("Thanks");
        PressAnyKey();
        return false;
    }

    private void DeleteGremlin()
    {
        DisplayMenu(ConsoleColor.DarkRed, "== Delete Gremlin ==\n");
        try
        {
            Write("Please input an exising Gremlin Id: ");
            int userInput = int.Parse(ReadLine());
            if (_gRepo.DeleteGremlin(userInput))
            {
                WriteLine("Success!");
            }
            else
            {
                WriteLine("Failure");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }



        ReadKey();
    }

    private void UpdateGremlin()
    {
        Clear();


        ReadKey();
    }

    private void ViewAGremlin()
    {
        Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("== Gremlin Details ==");
        Console.ResetColor();

        try
        {
            Write("Please enter an Existing Gremlin Id: ");
            int gremlinId = int.Parse(ReadLine());

            var gremlinInDatabase = _gRepo.GetGremlin(gremlinId);
            if (gremlinInDatabase != null)
            {
                WriteLine(gremlinInDatabase);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine($"The Gremlin with the id: {gremlinId} doesn't exist!");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }

        ReadKey();
    }

    private void SomethingWentWrong(Exception ex)
    {
        WriteLine($"Something went wrong: {ex.Message}.");
    }

    private void ViewAllGremlins()
    {
        DisplayMenu(ConsoleColor.Yellow, "== View All Gremlins==\n");
        foreach (var gremlin in _gRepo.GetGremlins())
        {
            WriteLine(gremlin);
            Console.ResetColor();
        }

        ReadKey();
    }

    private void DisplayMenu(ConsoleColor color, string menuString)
    {
        Clear();
        Console.ForegroundColor = color;
        WriteLine(menuString);
        Console.ResetColor();
    }

    private void AddAGremlin()
    {
        Clear();
        Gremlin gremlin = new Gremlin();
        try
        {

            WriteLine("Enter the Gremlin Name.");
            gremlin.Name = ReadLine();

            WriteLine("Enter the Gremlin Age.");
            gremlin.Age = int.Parse(ReadLine());


        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
            //if anything goes wrong
            //lets clear the form
            gremlin = null;
        }

        if (_gRepo.AddGremlin(gremlin))
        {
            WriteLine("Success");
        }
        else
        {
            WriteLine("Failure");
        }
        ReadKey();
    }

    private void DeleteHunterData()
    {
        DisplayMenu(ConsoleColor.DarkRed, "== Delete Existing Hunter ==");
        try
        {
            WriteLine("Please enter an existing Hunter Id.");
            int hunterId = int.Parse(ReadLine());
            if (_gHRepo.DeleteHunter(hunterId))
            {
                WriteLine("Success!");
            }
            else
            {
                WriteLine("Failure!");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }
    }

    private void UpdateHunterData()
    {
        DisplayMenu(ConsoleColor.DarkBlue, "== Update Hunter ==");
        try
        {
            WriteLine("Please enter an existing Hunter Id.");
            int hunterId = int.Parse(ReadLine());
            GremlinHunter hunter = _gHRepo.GetGremlinHunter(hunterId);
            if (hunter != null)
            {
                GremlinHunter Updatedhunter = Init_GremlinHunter();
                if (_gHRepo.UpdateGremlinHunterData(hunter.Id, Updatedhunter))
                {
                    WriteLine("Success!");
                }
                else
                {
                    WriteLine("Fail");
                }
            }
            else
            {
                WriteLine($"The hunter with the Id: {hunterId} doesn't exist!");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }


        ReadKey();
    }

    private void ViewHunterById()
    {
        DisplayMenu(ConsoleColor.DarkBlue, "== View Hunter ==");
        try
        {
            WriteLine("Please enter an existing Hunter Id.");
            int hunterId = int.Parse(ReadLine());
            var hunter = _gHRepo.GetGremlinHunter(hunterId);
            if (hunter != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                WriteLine(hunter);
                Console.ResetColor();
            }
            else
            {
                WriteLine($"The hunter with the Id: {hunterId} doesn't exist!");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }

        ReadKey();
    }

    private void ViewAllHunters()
    {
        DisplayMenu(ConsoleColor.DarkBlue, "== View All Hunters ==");
        foreach (var hunter in _gHRepo.GetGremlnHunters())
        {
            WriteLine(hunter);
            Console.ResetColor();
        }

        ReadKey();
    }

    private void AddAHunter()
    {
        DisplayMenu(ConsoleColor.Green, "== Add A Hunter");
        GremlinHunter hunter = Init_GremlinHunter();
        if (_gHRepo.AddGremlinHunter(hunter))
        {
            WriteLine("Success");
        }
        else
        {
            WriteLine("Failure");
        }
        ReadKey();
    }

    private GremlinHunter Init_GremlinHunter()
    {
        GremlinHunter hunter = new GremlinHunter();

        WriteLine("Input the Gremlin Hunter Name.");
        hunter.Name = ReadLine();

        bool hasAllCaputuredGemlins = false;

        while (hasAllCaputuredGemlins == false)
        {
            WriteLine("Does this hunter have any captured gremlins? y/n");
            var userInput = ReadLine();
            if (userInput == "Y".ToLower())
            {
                var gremlinToAdd = new Gremlin();
                WriteLine("Enter the Gremlin Name.");
                gremlinToAdd.Name = ReadLine();

                WriteLine("Enter the Gremlin Age.");
                gremlinToAdd.Age = int.Parse(ReadLine());

                //add gremlin to database
                _gRepo.AddGremlin(gremlinToAdd);
                //add gremling to the hunter that actuall caught it.
                hunter.CapturedGremlins.Add(gremlinToAdd);
            }
            else
            {
                hasAllCaputuredGemlins = true;
            }
        }

        return hunter;
    }

    private void PressAnyKey()
    {
        WriteLine("Press Any Key to continue.");
        ReadKey();
    }
}
