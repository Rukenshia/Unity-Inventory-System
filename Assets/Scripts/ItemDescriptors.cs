using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;

public class ItemDescriptors {
    private Dictionary<string, ItemDescriptor> _descriptors;

    public ItemDescriptors()
    {
        _descriptors = new Dictionary<string, ItemDescriptor>();
    }

    public bool Initialize()
    {
        return this.LoadDescriptors(Application.dataPath + "/data/descriptors.json");
    }

    public IItemDescriptor Find(string name)
    {
        return (IItemDescriptor)_descriptors[name];
    }

    private bool LoadDescriptors(string path)
    {
        _descriptors.Clear();

        string obj = "";

        // Check for file Existance
        if (!File.Exists(path))
        {
            return false;
        }

        obj = File.ReadAllText(path);

        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(obj);

        for (int i = 0; i < data.Count; i++)
        {
            ItemDescriptor d = new ItemDescriptor(data[i]);
            _descriptors.Add(d.Name, d);
        }

        Debug.Log("Found " + data.Count + " items descriptors.");
        return true;
    }
}
