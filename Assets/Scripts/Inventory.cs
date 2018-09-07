using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    public static Inventory instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion
    public List<Item> items = new List<Item>();
    public int space = 15;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("inventory Full");
                return false;
            }
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            items.Add(item);
            Debug.Log(items.Count);
            return true;
        }
        return false;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
