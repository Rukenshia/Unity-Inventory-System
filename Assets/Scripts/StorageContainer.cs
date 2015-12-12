using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    // Implements most of IStorage interface but not direct Stack access.
    class StorageContainer
    {
        private List<IStorage> _storages;
        
        public StorageContainer()
        {
            _storages = new List<IStorage>();
        }
        
        public bool AddStack(IItemStack stack)
        {
            // get the first available storage
            foreach (IStorage storage in _storages)
            {
                var stacks = storage.Get(stack.Descriptor);
                if (storage.CanAdd(stack))
                {
                    return storage.AddStack(stack);
                }
            }
            return false;
        }

        public bool CanAdd(IItemStack stack)
        {
            foreach (IStorage storage in _storages)
            {
                if (storage.CanAdd(stack))
                    return true;
            }
            return false;
        }

        public bool CanAdd(float weight)
        {
            foreach (IStorage storage in _storages)
            {
                if (storage.CanAdd(weight))
                    return true;
            }
            return false;
        }

        public bool Has(IItemDescriptor descriptor)
        {
            foreach (IStorage storage in _storages)
            {
                if (storage.Has(descriptor))
                    return true;
            }
            return false;
        }

        public List<IItemStack> Get(IItemDescriptor descriptor)
        {
            return new List<IItemStack>();
        }

        public List<IStorage> Storages
        {
            get
            {
                return _storages;
            }
        }

        public float Weight
        {
            get
            {
                float weight = 0.0f;
                foreach (IStorage storage in _storages)
                    weight += storage.Weight;
                return weight;
            }
        }
    }
}
