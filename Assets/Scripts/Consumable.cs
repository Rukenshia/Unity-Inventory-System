using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Consumable : Item, IConsumable
    {
        protected bool _used = false;

        public Consumable(IItemDescriptor descriptor) : base(descriptor)
        {

        }

        public bool Use()
        {
            return true;
        }

        public bool Used
        {
            get { return _used; }
        }
    }
}
