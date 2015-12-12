using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Storage : Item, IStorage
    {
        private List<IItemStack> _stacks;

        public Storage(IItemDescriptor descriptor) : base(descriptor)
        {
            _stacks = new List<IItemStack>();
        }

        private SimpleJSON.JSONNode _getAttribute(string name)
        {
            SimpleJSON.JSONNode attr;
            this.Descriptor.Attributes.TryGetValue(name, out attr);
            return attr;
        }

        public bool AddQuantity(IItemDescriptor descriptor, int quantity)
        {
            List<IItemStack> stacks = this.Get(descriptor);
            if (stacks.Count == 0)
                return false;

            // Always add to first stack when using this shortcut method.
            // The 'CanAdd' requirement will be checked by AddQuantity, no need to double-call it.
            return stacks[0].AddQuantity(quantity);
        }

        public bool AddStack(IItemStack stack)
        {
            if (!this.CanAdd(stack) || stack.Quantity == 0)
                return false;
            _stacks.Add(stack);
            return true;
        }

        public bool CanAdd(IItemStack stack)
        {
            return !_stacks.Contains(stack) && this.Capacity >= this.ContentWeight + stack.Weight;
        }

        public bool CanAdd(float weight)
        {
            return this.Capacity >= this.ContentWeight + weight;
        }

        public List<IItemStack> Get(IItemDescriptor descriptor)
        {
            List<IItemStack> stacks = new List<IItemStack>();

            foreach(IItemStack stack in this.Stacks)
            {
                if (stack.Descriptor == descriptor)
                    stacks.Add(stack);
            }
            return stacks;
        }

        public bool Has(IItemDescriptor descriptor)
        {
            foreach(IItemStack stack in this.Stacks)
            {
                if (stack.Descriptor == descriptor)
                    return true;
            }
            return false;
        }

        public bool MoveStack(IItemStack stack, IStorage newStorage)
        {
            if (!this.Stacks.Contains(stack))
                return false;

            if (!newStorage.CanAdd(stack))
                return false;

            this.RemoveStack(stack);
            if (newStorage.AddStack(stack))
                return true;

            // Recover the stack
            this.AddStack(stack);
            return false;
        }

        public bool RemoveStack(IItemStack stack)
        {
            if (stack.Storage == this)
                stack.Storage = null;
            _stacks.Remove(stack);
            return !_stacks.Contains(stack);
        }

        public List<IItemStack> Stacks
        {
            get { return _stacks; }
        }

        public float Capacity
        {
            get
            {
                return _getAttribute("capacity").AsFloat;
            }
        }

        public float ContentWeight
        {
            get
            {
                float weight = 0.0f;
                foreach(IItemStack stack in _stacks)
                    weight += stack.Weight;
                return weight;
            }
        }

        public override float Weight
        {
            get
            {
                return base.Weight + this.ContentWeight;
            }
        }
    }
}
