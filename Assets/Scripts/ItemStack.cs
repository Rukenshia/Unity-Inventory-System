using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class ItemStack : IItemStack
    {
        private IItemDescriptor _descriptor;
        private List<IItem> _items;
        private int _quantity;

        public ItemStack(IItemDescriptor descriptor)
        {
            _descriptor = descriptor;
        }

        ~ItemStack()
        {
            this._descriptor = null;
        }

        public override bool Add(IItem item)
        {
            if (_items.Contains(item))
                return false;

            _items.Add(item);
            return true;
        }

        public override bool AddQuantity(int quantity)
        {
            _quantity += quantity;
            return true;
        }

        public override IItemDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public override List<IItem> Items
        {
            get { return _items; }
        }

        public override int Quantity
        {
            get { return _quantity; }
        }

        public override float Weight
        {
            get { return _descriptor.Weight * _quantity; }
        }

        public override float Volume
        {
            get { return _descriptor.Volume * _quantity; }
        }
    }
}
