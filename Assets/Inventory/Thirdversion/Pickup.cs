using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   
    public GameObject itemButton;
    private void Start()
    {
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<thirdInventory>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            for (int i = 0; i < thirdInventory.instance.slots.Length; i++) {
                if (thirdInventory.instance.isFull[i] == 0) {
                    thirdInventory.instance.isFull[i] = 1;
                    Instantiate(itemButton, thirdInventory.instance.slots[i].transform,false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
