using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IStorage : IItem
    {
        List<IItemStack> Stacks { get; }
        bool AddStack(IItemStack stack);
        bool RemoveStack(IItemStack stack);
        bool AddQuantity(IItemDescriptor descriptor);
    }
}
