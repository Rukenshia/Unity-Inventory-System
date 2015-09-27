using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IItemStack
    {
        IItemDescriptor Descriptor { get; }
        List<IItem> Items { get; }
        bool Add(IItem item);
        bool AddQuantity(int quantity);

        int Quantity { get; }
        float Volume { get; }
        float Weight { get; }
    }
}
