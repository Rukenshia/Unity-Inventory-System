using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IItemStack
    {
        IItemDescriptor Descriptor { get; }
        IStorage Storage { get; set; }
        List<IItem> Items { get; }
        bool Add(IItem item);
        bool AddQuantity(int quantity);
        bool Remove(IItem item);
        bool RemoveQuantity(int quantity, bool force = false);
        bool Merge(IItemStack other);

        int Quantity { get; }
        float Volume { get; }
        float Weight { get; }
    }
}
