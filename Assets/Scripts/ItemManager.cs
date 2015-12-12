using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ItemManager : MonoBehaviour {
    protected ItemDescriptors _descriptors;
	// Use this for initialization
	void Start () {
        _descriptors = new ItemDescriptors();
        _descriptors.Initialize();

        // TODO: Hook Descriptors

        StorageContainer sc = new StorageContainer();
        Storage s = (Storage)_descriptors.Find("Backpack").Create();

        // Add the Storage to our StorageContainer
        sc.Storages.Add(s);

        ItemStack stack = new ItemStack(_descriptors.Find("Whiskey Bottle"), s);
        stack.AddQuantity(80);
        // Automatically add the Stack to the first available storage of the Container.
        sc.AddStack(stack);

        stack = new ItemStack(_descriptors.Find("Botan"));
        stack.AddQuantity(1);
        // Automatically add the Stack to the first available storage of the Container.
        sc.AddStack(stack);

        foreach (IStorage storage in sc.Storages)
        {
            string msg = "";
            msg += "Total Storage weight: " + storage.Weight / 1000.0f + "kg, Content Weight: " + System.Math.Round(storage.ContentWeight / 1000.0f, 2) + "/" + storage.Capacity / 1000.0f + "kg\n";
            foreach (IItemStack itemStack in storage.Stacks)
            {
                msg += itemStack.Quantity + "x " + itemStack.Descriptor.Name + " (" + itemStack.Weight / 1000.0f + "kg)\n";
            }
            Debug.Log(msg);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
