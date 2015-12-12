using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class ItemStack : Destroyable, IItemStack
    {
        private IItemDescriptor _descriptor;
        private IStorage _storage;
        private List<IItem> _items;
        private int _quantity;

        public ItemStack(IItemDescriptor descriptor)
        {
            _items = new List<IItem>();
            _descriptor = descriptor;
        }

        public ItemStack(IItemDescriptor descriptor, IStorage storage) : this(descriptor)
        {
            Storage = storage;
        }

        ~ItemStack()
        {
            this._descriptor = null;
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
            if (this.Storage != null && !this.Storage.CanAdd(this.Descriptor.Weight * quantity))
                return false;
            
            for (int i = 0; i < quantity; i++)
                _items.Add(this.Descriptor.Create());
            _quantity += quantity;
            return true;
        }

        public bool Merge(IItemStack other)
        {
            if (other.Descriptor != this.Descriptor)
                return false;

            foreach (IItem item in other.Items)
            {
                other.Remove(item);
                this.Add(item);
            }

            return true;
        }

        public bool Remove(IItem item)
        {
            if (!this.Items.Contains(item))
                return false;

            return this.Items.Remove(item);
        }

        public bool RemoveQuantity(int quantity, bool force = false)
        {
            if (this.Quantity < quantity)
            {
                if (!force)
                    return false;

                this.Items.Clear();
                return true;
            }
            this.Items.RemoveRange(0, quantity);
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
            get { return this.Items.Count; }
        }

        public IStorage Storage
        {
            get { return _storage; }
            set
            {
                if (!value.CanAdd(this))
                    throw new Exception("Trying to add ItemStack to Storage that cant hold it.");

                if (this.Storage != null)
                    this.Storage.RemoveStack(this);

                if (value == null)
                {
                    _storage = null;
                    return;
                }

                if (!value.Stacks.Contains(this))
                    value.AddStack(this);

                _storage = value;
            }
        }

        public float Weight
        {
            get { return _descriptor.Weight * this.Quantity; }
        }
    }
}
