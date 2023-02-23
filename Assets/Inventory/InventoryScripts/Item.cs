using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="New item",menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemInfo;
    public Sprite itemImage;
    public int itemHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;
    public void Use() {
        Debug.Log("Using Item");
        thisEvent.Invoke();
    }
}
