using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Item : Destroyable, IItem
    {
        protected IItemDescriptor _descriptor;
        protected IItemStack _stack;


        public Item(IItemDescriptor descriptor)
        {
            _descriptor = descriptor;
        }

        public Item(IItemDescriptor descriptor, IItemStack stack) : this(descriptor)
        {
            _stack = stack;
        }

        public IItemDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public IItemStack Stack
        {
            get { return _stack; }
        }

        public virtual float Weight
        {
            get { return _descriptor.Weight; }
        }

        public IConsumable AsConsumable()
        {
            if (this.Descriptor.Type == ItemType.Consumable)
                return (IConsumable)this;
            return null;
        }

        public IStorage AsStorage()
        {
            if (this.Descriptor.Type == ItemType.Storage)
                return (IStorage)this;
            return null;
        }
    }
}