using System;
using SwinAdventure;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] idents, string name, string description) : base(idents, name, description)
        {
            _inventory = new Inventory();
        }

        public GameObject? Locate(string id) //Attempts to locate an item in the bag.
        {
            if (AreYou(id))
            {
                return this; // checks if the id matches the bag then returns "this"
            }
            else if(_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory //Returns the contents of the bag
        {
            get
            {
                return _inventory;
            }
        }

        public override string LongDescription // Returns the long description of the bag and the items in it
        {
            get
            {
                return "In the "+ Name + " you can see: " + _inventory.ItemList;
            }
        }

        public bool IsEmpty // Checks to see if something is empty by checking if the item list is empty, if it is then it returns true otherwise false
        {
            get
            {
                if (_inventory.ItemList == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}