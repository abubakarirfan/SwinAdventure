using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask user for name and description
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your description: ");
            string desc = Console.ReadLine();

            //creation of all the required objects
            Player player = new Player(name, desc);
            Path north = new Path(new string[] { "north" }, "north", "blah bah");
            Location castle = new Location(new string[] { "Castle" }, "Fort", "Standing in Castle Fort");
            Location fort = new Location(new string[] { "fort" }, "fort", "hiding place");
            Item sword = new Item(new string[] { "Sword" }, "A Weapon", "Used to kill the enemy");
            Item gun = new Item(new string[] { "Gun" }, "A Weapon", "Used to kill the enemy");
            Bag bag = new Bag(new string[] { "Bag" }, "A yellow", "A box used to carry items");
            Item banana = new Item(new string[] { "Banana" }, "Fruit", "Food to increase energy");
            Item wrench = new Item(new string[] { "Wrench" }, "A blue", "used to fix things");
            Path south = new Path(new string[] { "south" }, "south", "blah");


            //assignment to locations/inventory/......
            player.Location = castle;
            player.Inventory.Put(sword);
            player.Inventory.Put(gun);
            castle.Inventory.Put(gun);
            player.Inventory.Put(bag);
            bag.Inventory.Put(banana);
            player.Location.AddPath(north);
            north.Destination = fort;
            fort.Inventory.Put(wrench);
            south.Destination = castle;
            fort.AddPath(south);

            //set up command processor and commands
            CommandProcessor commandProcessor = new CommandProcessor();
            LookCommand lookCommand = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();
            PutCommand putCommand = new PutCommand();
            TakeCommand takeCommand = new TakeCommand();

            //add commands to command processor list
            commandProcessor.AddCommand(lookCommand);
            commandProcessor.AddCommand(moveCommand);
            commandProcessor.AddCommand(takeCommand);
            commandProcessor.AddCommand(putCommand);

            string userCommand;
            //user interaction with game
            do
            {
                Console.Write("Command: ");
                userCommand = Console.ReadLine();
                string[] splitCommand = userCommand.Split(' ');

                string outputCommand = commandProcessor.Execute(player,splitCommand);
                if (userCommand != "quit")
                {
                    Console.WriteLine(outputCommand);
                }
            } while (userCommand != "quit");

        }
    }
}
