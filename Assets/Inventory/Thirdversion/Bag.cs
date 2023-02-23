using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    bool isClosed;
    public GameObject bag;

     void Update()
    {
        openBag();
    }
    void openBag() {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isClosed = !isClosed;
            bag.SetActive(isClosed);
            
        }
    }

    public void OpenCloseBag()
    {
        if (isClosed == true)
        {
            bag.SetActive(true);
            isClosed = false;
        }
        else
        {
            bag.SetActive(false);
            isClosed = true;
        }
        
    }
}
