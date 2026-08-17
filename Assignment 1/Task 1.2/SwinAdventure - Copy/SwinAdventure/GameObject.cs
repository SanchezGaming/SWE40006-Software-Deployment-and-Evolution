using System;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string description) : base (ids)
        {
            _name = name;
            _description = description;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string ShortDescription
        {
            get
            {
                return $"{Name} ({FirstId()})";
            }
        }

        public virtual string LongDescription
        {
            get
            {
                return _description;
            }            
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_description);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _name = reader.ReadLine() ?? "";
            _description = reader.ReadLine() ?? "";
        }
    }
}