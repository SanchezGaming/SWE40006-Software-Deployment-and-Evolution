using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        public List<string> Identifiers
        {
            get
            {
                return _identifiers;
            }
        }

        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FirstId()
        {
            if (_identifiers.Any())
            {
                return _identifiers.First();
            }
            else
            {
                return "";
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public bool RemoveIdentifier(string id)
        {

            id = id.ToLower();

            if (_identifiers.Contains(id) && _identifiers.Count > 1)
            {
                _identifiers.Remove(id); //This process checks to see if the _identifiers exist and are more than 1
                return true;
            }
            else if (_identifiers.Contains(id) && _identifiers.Count == 1)
            {
                return false; //This process checks to see if the _identifiers is equal to 1, if true, return false.
            }
            else if (!_identifiers.Contains(id))
            {
                return false; //Checks to see if id exists, if false, return false.
            }
            else
            {
                return false; //Otherwise return false.
            }
        }

        public void PrivilegeEscalation(string pin)
        {
            string studentPin = "5488";
            if (pin == studentPin)
            {
                _identifiers[0] = ("104415488");
            }
        }
    }
}