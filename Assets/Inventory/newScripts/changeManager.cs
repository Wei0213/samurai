using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public Inventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public Item currentItem;
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }
     void MakeInventorySlots()
     {
         if (playerInventory)
         {
             for (int i = 0; i < playerInventory.itemList.Count; i++)
             {
                 GameObject temp =Instantiate(blankInventorySlot,
                     inventoryPanel.transform.position, Quaternion.identity);
                 temp.transform.SetParent(inventoryPanel.transform);
                 changeSlot newSlot = temp.GetComponent<changeSlot>();
                 if (newSlot)
                 {
                     newSlot.Setup(playerInventory.itemList[i], this);
                 }
             }
         }
     }
    private void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false);
    }
    public void SetupDescriptionAndButton(string newDescriptionString,
        bool isButtonUsable,Item newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
        }
    }
}
