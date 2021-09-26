using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();

            for(int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i]);
            }
        }

        public bool AreYou(string id)
        {
            for (int i = 0; i < _identifiers.Count; i++)
            {
                if(_identifiers[i].ToLower() == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }
        }

        public void AddIdentifier(string id)
        {
            string lowerCaseObject = id.ToLower();
            _identifiers.Add(lowerCaseObject);
        }


    }
}
