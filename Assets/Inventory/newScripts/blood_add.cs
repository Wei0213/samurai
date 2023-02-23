using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blood_add : MonoBehaviour
{
    public Slider 血量計;

    

    public void Use()
    {

        血量計.value += 10;
    }
}
