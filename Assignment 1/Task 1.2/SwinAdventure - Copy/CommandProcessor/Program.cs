using System;
using System.Numerics;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string Execute(Player p, string[] playercommand)
        {
            string keyword = playercommand[0].ToLower();

            foreach (Command command in _commands)
            {
                if (command.AreYou(keyword))
                {
                    return command.Execute(p, playercommand);
                }
            }

            return $"I don't understand '{keyword}' command.";
        }
    }
}