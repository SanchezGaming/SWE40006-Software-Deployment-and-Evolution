using System;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;

        public Path(string[] idents, string name, string description, Location destination) : base(idents, name, description)
        {
            _destination = destination;
        }

        public void Move(Player p)
        {
            p.CurrentLocation = _destination;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
            }
        }
    }
}