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

        public bool AddQuantity(IItemDescriptor descriptor)
        {
            return false;
        }

        public bool AddStack(IItemStack stack)
        {
            if (_stacks.Contains(stack))
                return false;
            _stacks.Add(stack);
            return true;
        }

        public bool RemoveStack(IItemStack stack)
        {
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
                float volume = this.Descriptor.Volume;
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
