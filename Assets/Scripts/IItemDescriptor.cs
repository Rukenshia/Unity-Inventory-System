using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public enum ItemType
    {
        Item,
        Consumable,
        Storage
    };

    public interface IItemDescriptor
    {
        string Name { get; }
        string Description { get; }
        ItemType Type { get; }
        float Weight { get; }
        float Volume { get; }
        Dictionary<string, SimpleJSON.JSONNode> Attributes { get; }

        IItem Create();
    }
}
