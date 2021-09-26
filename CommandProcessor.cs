using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        List<Command> _commands;
        
        public CommandProcessor()
        {
            _commands = new List<Command>();
        }


        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string Execute(Player player, string[] text)
        {
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0]))
                {
                    return command.Execute(player, text);
                }
            }
            return "Command does not exist";
        }

    }
}
