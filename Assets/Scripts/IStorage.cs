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
        bool CanAdd(IItemStack stack);
        bool CanAdd(float volume);
        bool Has(IItemDescriptor descriptor);
        List<IItemStack> Get(IItemDescriptor descriptor);

        bool MoveStack(IItemStack stack, IStorage newStorage);
        bool RemoveStack(IItemStack stack);
    }
}
