using System;
using SwinAdventure;
using Path = SwinAdventure.Path;

namespace SwinAdventure
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            string playerName = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your class: ");
            string playerDescription = Console.ReadLine() ?? "";

            Player player = new Player(playerName, playerDescription);

            Location room1 = new Location(new string[] { "bedroom" }, "a room", "a small room with a single door (north), a hatch leading to the attic (up) and a window");
            Location room2 = new Location(new string[] { "kitchen" }, "another room", "connected to the first room by a door, has a kitchen, a hatch leading to the basement (down), and a Locked door leading outside (east)");
            Location outside = new Location(new string[] { "outside" }, "the outside world", "a vast open space with a clear blue sky and a bright sun");
            Location attic = new Location(new string[] { "attic" }, "an attic", "a dark and dusty attic filled with old furniture and cobwebs");
            Location basement = new Location(new string[] { "basement" }, "a basement", "a damp and musty basement with a single light bulb hanging from the ceiling");

            Path pathToRoom2 = new Path(new string[] { "north" }, "a north path", "a path leading to the kitchen", room2);
            Path pathToRoom1 = new Path(new string[] { "south" }, "a south path", "a path leading to the bedroom", room1);
            Path pathOutside = new Path(new string[] { "east" }, "an east path", "a path leading to freedom", outside);
            Path pathToRoom2Squared = new Path(new string[] { "west" }, "a west path", "a path leading back to the kitchen", room2);
            Path pathToAttic = new Path(new string[] { "up" }, "an up path", "a ladder leading to the attic", attic);
            Path pathToBasement = new Path(new string[] { "down" }, "a down path", "a ladder leading to the basement", basement);


            room1.AddPath("north", pathToRoom2);
            room2.AddPath("south", pathToRoom1);
            room2.AddPath("east", pathOutside);
            outside.AddPath("west", pathToRoom2Squared);
            room1.AddPath("up", pathToAttic);
            room2.AddPath("down", pathToBasement);
            attic.AddPath("down", pathToRoom1);
            basement.AddPath("up", pathToRoom2);

            player.MoveToLocation(room1);

            Item item1 = new Item(new string[] { "scythe" }, "A Scythe", "a sharp rounded blade on a long pole\n");
            Item item2 = new Item(new string[] { "dagger" }, "A Dagger", "a short sharp blade with a hilt\n");

            player.Inventory.Put(item1);
            player.Inventory.Put(item2);

            Bag bag = new Bag(new string[] { "bag" }, "A Bag", "Seemingly bottomless bag");
            player.Inventory.Put(bag);

            Item gem = new Item(new string[] { "gem" }, "A Gem", "a sparkling gem");
            bag.Inventory.Put(gem);

            LookCommand lookCommand = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();

            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.AddCommand(lookCommand);
            commandProcessor.AddCommand(moveCommand);

            Console.WriteLine("Welcome to SwinAdventure, " + player.Name + "!");
            Console.WriteLine("Available commands:");
            Console.WriteLine("- look (item / location)");
            Console.WriteLine("- move / go (direction) [password]");
            Console.WriteLine("- exit");

            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine() ?? "";

                string[] formattedCommand = command.ToLower().Split(" ");

                if (formattedCommand[0] == "exit")
                {
                    finished = true;
                    Console.WriteLine("Goodbye!");
                    break;
                }

                Console.WriteLine(commandProcessor.Execute(player, formattedCommand));
            }

            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                player.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }

            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                player.LoadFrom(reader);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}