using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdInventory : MonoBehaviour
{
    public static thirdInventory instance;
    private void Awake()
    {
        instance = this;

    }
    public int[] isFull;
    public GameObject[] slots;
}
