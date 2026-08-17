using System;
using SwinAdventure;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] idents) : base(idents)
        {
        }

        public abstract string Execute(Player p, string[] text);
    }
}