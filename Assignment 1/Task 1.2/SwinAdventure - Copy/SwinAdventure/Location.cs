using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Dictionary<string, Path> _paths;
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Path>();
        }
        public Inventory Inventory
        {
            get 
            {
                return _inventory;
            }
        }

        public override string LongDescription
        {
            get
            {
                return $"{base.LongDescription}\nItems: {_inventory.ItemList}";
            }
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            GameObject? itemFound = _inventory.Fetch(id);

            return itemFound;
        }

        public void AddItem(Item item)
        {
            _inventory.Put(item);
        }

        public void AddPath(string direction, Path path)
        {
            _paths[direction] = path;
        }

        public Dictionary<string, Path> GetAvailablePaths()
        {
            return _paths;
        }

        public Path? GetPath(string direction)
        {
            if (_paths.ContainsKey(direction))
            {
                return _paths[direction];
            }
            return null;
        }

        public Inventory inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}