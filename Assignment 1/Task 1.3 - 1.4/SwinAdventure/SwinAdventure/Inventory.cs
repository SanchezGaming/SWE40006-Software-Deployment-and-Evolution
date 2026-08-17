using System;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public List<Item> Items
        {
            get
            {
                return _items;
            }
        }

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items) //foreach item class item in our list return true if true
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false; // return false if no
        }

        public void Put(Item itm) //adds item class item to our list.
        {
            _items.Add(itm);
        }

        public Item? Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id)) //checks to see if the item we want to take exists
                {
                    Item takeItem = i;
                    _items.Remove(i);
                    return takeItem; //removes item
                }
            }
            return null; //otherwise returns null
        }

        public Item? Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id)) //checks to see if item we're fetching exists
                {
                    return i; //returns item we fetched if true
                }
            }
            return null; //returns null otherwise
        }

        public string ItemList
        {
            get
            {
                string listitm = string.Empty;

                List<string> itemDescriptionsList = new List<string>();
                foreach(Item i in _items) //iterates over all items in list until none remain
                {
                    itemDescriptionsList.Add(i.ShortDescription);
                }

                listitm = string.Join(", ", itemDescriptionsList); //joins all items in list together with a comma and space in between
                return listitm; //returns item name and description.
            }
        }

        public bool Put_ItemWithLimit(Item itm)
        {
            if (itm.Identifiers.Count >= 3)
            {
                foreach (var existingItem in _items)
                {
                    foreach (var id in itm.Identifiers)
                    {
                        if (existingItem.AreYou(id))
                        {
                            return false;
                        }
                    }
                }
            }
            _items.Add(itm);
            return true;
        }
    }
}