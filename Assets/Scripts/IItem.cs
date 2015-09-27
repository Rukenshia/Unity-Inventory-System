using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IItem : IDestroyable
    {
        IItemDescriptor Descriptor { get; }
        float Weight { get; }
        float Volume { get; }

        IConsumable AsConsumable();
        IStorage AsStorage();
    }
}
