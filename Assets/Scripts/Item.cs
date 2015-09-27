using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Item : IItem
    {
        protected IItemDescriptor _descriptor;

        public Item(IItemDescriptor descriptor)
        {
            _descriptor = descriptor;
        }

        ~Item()
        {
            this._descriptor = null;
        }

        public override IItemDescriptor Descriptor
        {
            get { return _descriptor; }
        }
    }
}