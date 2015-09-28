using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ItemManager : MonoBehaviour {
    protected ItemDescriptors _descriptors;
	// Use this for initialization
	void Start () {
        _descriptors = new ItemDescriptors();
        _descriptors.Initialize();

        Storage s = (Storage)_descriptors.Find("Backpack").Create();
        ItemStack stack = new ItemStack(_descriptors.Find("Whiskey Bottle"), s);
        stack.AddQuantity(8);
        s.AddStack(stack);
        stack = new ItemStack(_descriptors.Find("Botan"));
        stack.AddQuantity(1);
        s.AddStack(stack);

        foreach (IItemStack itemStack in s.Stacks)
        {
            Debug.Log(itemStack.Quantity + "x " + itemStack.Descriptor.Name + " (" + itemStack.Weight / 1000.0f + "kg)");
        }
        Debug.Log("-------------------\nTotal Storage weight: " + s.Weight / 1000.0f + "kg, Volume: " + System.Math.Round(s.ContentVolume / 1000.0f, 2) + "/" + s.Volume / 1000.0f + "l");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
