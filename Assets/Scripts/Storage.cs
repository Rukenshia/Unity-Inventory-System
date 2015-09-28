using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

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

        public bool AddQuantity(IItemDescriptor descriptor)
        {
            return false;
        }

        public bool AddStack(IItemStack stack)
        {
            if (!this.CanAdd(stack))
                return false;
            _stacks.Add(stack);
            return true;
        }

        public bool CanAdd(IItemStack stack)
        {
            return !_stacks.Contains(stack) && this.Volume - this.ContentVolume >= stack.Volume;
        }

        public bool CanAdd(float volume)
        {
            return this.Volume - this.ContentVolume >= volume;
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

        public float ContentVolume
        {
            get
            {
                float volume = 0.0f;
                foreach(IItemStack stack in _stacks)
                    volume += stack.Volume;
                return volume;
            }
        }

        public override float Weight
        {
            get
            {
                float weight = base.Weight;
                foreach (IItemStack stack in _stacks)
                    weight += stack.Weight;
                return weight;
            }
        }
    }
}
