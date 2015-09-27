using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public enum ItemType
    {
        Item,
        Consumable,
        Storage
    };

    public interface IItemDescriptor
    {
        string Name { get; }
        string Description { get; }
        ItemType Type { get; }
        float Weight { get; }
        float Volume { get; }
        Dictionary<string, SimpleJSON.JSONNode> Attributes { get; }

        IItem Create();
    }

    public abstract class IItem : IDestroyable
    {
        public abstract IItemDescriptor Descriptor { get; }
        public virtual float Weight
        {
            get { return Descriptor.Weight; }
        }
        public virtual float Volume
        {
            get { return Descriptor.Volume; }
        }
    }

    public abstract class IItemStack : IItem
    {
        public abstract List<IItem> Items { get; }
        public abstract bool Add(IItem item);
        public abstract bool AddQuantity(int quantity);

        public abstract int Quantity { get; }
    }

    public interface IStorage
    {
        IItemDescriptor Descriptor { get; }
        List<IItemStack> Stacks { get; }
        bool AddStack(IItemStack stack);
        bool RemoveStack(IItemStack stack);
        bool AddQuantity(IItemDescriptor descriptor);
    }

    public class IDestroyable
    {
        public delegate void OnDestroyHandler(IDestroyable obj);
        public OnDestroyHandler OnDestroy;

        ~IDestroyable()
        {
            OnDestroy = null;
        }

        public void Destroy()
        {
            if (this.OnDestroy == null)
                return;

            this.OnDestroy(this);
        }
    }
}
