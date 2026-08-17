using System;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "go", "head", "leave"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length < 2)
            {
                return "Move where?";
            }

            if (!AreYou(text[0]))
            {
                return "Error in move input";
            }

            string direction = text[1].ToLower();
            
            if (p.CurrentLocation == null)
            {
                return "You are not at a valid location";
            }
            
            Path? path = p.CurrentLocation.GetPath(direction);

            if (path != null)
            {
                path.Move(p);
                return $"You move {direction} to {p.CurrentLocation.Name}.";
            }
            else
            {
                return $"There is no path to the {direction}.";
            }
        }
    }
}