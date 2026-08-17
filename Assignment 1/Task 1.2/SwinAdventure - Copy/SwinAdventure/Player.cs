namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location? _location;

        public Player(string name, string desc) : base(new string[] { "player", "inventory" }, name, desc)
        {
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject? itemFound = _inventory.Fetch(id);

            if (itemFound != null)
            {
                return itemFound;
            }

            if (_location != null)
            {
                itemFound = _location.Locate(id);

                if (itemFound != null)
                {
                    return itemFound;
                }
            }
            return null;
        }

        public void MoveToLocation(Location newLocation)
        {
            _location = newLocation;
        }

        public GameObject? LocateInInventory(string id)
        {
            return _inventory.Fetch(id);
        }

        public override string LongDescription
        {
            get
            {
                string locationDescription = _location != null ? _location.Name : "nowhere";
                return $"You are {Name}, {base.LongDescription}\nYou are carrying:\n{_inventory.ItemList}\nYou are at: {locationDescription}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location? CurrentLocation
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(_inventory.ItemList);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string itemList = reader.ReadLine() ?? "";
            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(itemList);
            Console.WriteLine("\n");
            Console.WriteLine(LongDescription);
        }
    }
}