using System;
using System.ComponentModel;
using SwinAdventure;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 2 && text[1].ToLower() == "around")
            {
                return LookAtLocation(p);
            }

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look for that";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            string itemId = text[2];

            IHaveInventory? container;

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }

                string containerId = text[4];
                container = FetchContainer(p, containerId);
                if (container == null)
                {
                    return "I cannot find the " + containerId;
                }
            }

            return LookAtIn(itemId, container);
        }

        private string LookAtLocation(Player p)
        {
            if (p.CurrentLocation != null)
            {
                string description = p.CurrentLocation.LongDescription;

                Dictionary<string, Path> availablePaths = p.CurrentLocation.GetAvailablePaths();

                if (availablePaths.Count > 0)
                {
                    string directions = string.Join(", ", availablePaths.Keys);
                    description += $"\nAvailable paths: {directions}";
                }

                return description;
            }
            return "You are not at a valid location";
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            GameObject? container = p.Locate(containerId);
            if (container is IHaveInventory)
            {
                return container as IHaveInventory; //returns the container if it is found and is an IHaveInventory
            }
            return null; //returns null if the container is not found or is not an IHaveInventory
        }

        private string LookAtIn(string itemId, IHaveInventory container)
        {
            GameObject? item = container.Locate(itemId); //checks inventory container.
            if (item == null)
            {
                if (container is Player)
                {
                    return $"Cannot find the {itemId}";
                }
                else
                {
                    return $"Cannot find the {itemId} in the {container.Name}";
                }
            }
            else
            {
                return item.LongDescription; //returns the long description of the item if it is found in the container
            }
        }
    }
}