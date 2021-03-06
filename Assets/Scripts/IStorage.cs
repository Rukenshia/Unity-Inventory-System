﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IStorage : IItem
    {
        List<IItemStack> Stacks { get; }
        float ContentWeight { get; }
        float Capacity { get; }
        bool AddStack(IItemStack stack);
        bool AddQuantity(IItemDescriptor descriptor, int quantity);
        bool CanAdd(IItemStack stack);
        bool CanAdd(float volume);
        bool Has(IItemDescriptor descriptor);
        List<IItemStack> Get(IItemDescriptor descriptor);

        bool MoveStack(IItemStack stack, IStorage newStorage);
        bool RemoveStack(IItemStack stack);
    }
}
