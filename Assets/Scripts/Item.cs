using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Item : Destroyable, IItem
    {
        protected IItemDescriptor _descriptor;


        public Item(IItemDescriptor descriptor)
        {
            _descriptor = descriptor;
        }

        public IItemDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public virtual float Volume
        {
            get { return _descriptor.Volume; }
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