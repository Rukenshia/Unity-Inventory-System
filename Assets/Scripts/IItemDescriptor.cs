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
    public enum ItemSize
    {
        Tiny,
        Small,
        Medium,
        Large,
    };

public interface IItemDescriptor
    {
        string Name { get; }
        string Description { get; }
        ItemType Type { get; }
        float Weight { get; }
        ItemSize Size { get; }
        Dictionary<string, SimpleJSON.JSONNode> Attributes { get; }

        IItem Create();
    }
}
