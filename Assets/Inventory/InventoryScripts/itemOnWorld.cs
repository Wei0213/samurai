using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public InventoryManager thisManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()    //¾ß¸Ë³Æ 
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i]==null) {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetupEquip(thisItem);
        }
    }
}
