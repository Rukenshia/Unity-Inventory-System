using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class ItemStack : Destroyable, IItemStack
    {
        private IItemDescriptor _descriptor;
        private List<IItem> _items;
        private int _quantity;

        public ItemStack(IItemDescriptor descriptor)
        {
            _items = new List<IItem>();
            _descriptor = descriptor;
        }

        ~ItemStack()
        {
            this._descriptor = null;
        }

        public T As<T>()
        {
            return (T)System.Convert.ChangeType(this, typeof(T));
        }

        public bool Add(IItem item)
        {
            if (_items.Contains(item))
                return false;

            _items.Add(item);
            return true;
        }

        public bool AddQuantity(int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _items.Add(this.Descriptor.Create());
            _quantity += quantity;
            return true;
        }

        public IItemDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public List<IItem> Items
        {
            get { return _items; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public float Weight
        {
            get { return _descriptor.Weight * _quantity; }
        }

        public float Volume
        {
            get { return _descriptor.Volume * _quantity; }
        }
    }
}
