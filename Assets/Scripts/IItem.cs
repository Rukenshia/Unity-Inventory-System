using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IItem : IDestroyable
    {
        IItemDescriptor Descriptor { get; }
        IItemStack Stack { get; }
        float Weight { get; }

        IConsumable AsConsumable();
        IStorage AsStorage();
    }
}
