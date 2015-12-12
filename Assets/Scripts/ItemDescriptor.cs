using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{

    public class ItemDescriptor : IItemDescriptor
    {
        private string _name;
        private string _description;
        private float _weight;
        private float _volume;
        private ItemSize _size;
        private System.Type _class;
        private ItemType _itemType;
        private Dictionary<string, SimpleJSON.JSONNode> _attributes;

        public ItemDescriptor(SimpleJSON.JSONNode data)
        {
            _attributes = new Dictionary<string, SimpleJSON.JSONNode>();
            _name = data["name"];
            _description = data["description"];
            _weight = data["weight"].AsFloat;
            _volume = data["volume"].AsFloat;
            _size = (ItemSize)data["size"].AsInt;
            
            string type = data["type"];

            switch (type)
            {
                case "consumable":
                    _itemType = ItemType.Consumable;
                    _class = typeof(Consumable);
                    break;
                case "storage":
                    _itemType = ItemType.Storage;
                    _class = typeof(Storage);
                    break;
                default:
                    _itemType = ItemType.Item;
                    _class = typeof(Item);
                    break;
            }

            // Read the attributes
            List<string> keys = data["attributes"].GetKeys();

            foreach(string key in keys)
            {
                _attributes.Add(key, data["attributes"][key]);
            }
        }

        public ItemStack CreateStack()
        {
            return new ItemStack(this);
        }

        public IItem Create()
        {
            return (IItem)Activator.CreateInstance(_class, new object[] { this });
        }

        // Getters
        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public ItemType Type
        {
            get { return _itemType; }
        }

        public float Weight
        {
            get { return _weight; }
        }

        public ItemSize Size
        {
            get { return _size; }
        }

        public Dictionary<string, SimpleJSON.JSONNode> Attributes
        {
            get { return _attributes; }
        }
    }
}
