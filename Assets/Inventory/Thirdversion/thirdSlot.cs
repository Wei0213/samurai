using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdSlot : MonoBehaviour
{
    //private thirdInventory inventory;
    public int index;

    private void Start()
    {

        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<thirdInventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            thirdInventory.instance.isFull[index] = 0;
        }
    }
}
