using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 掉落死亡 : MonoBehaviour
{
    public float 掉落傷害;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().受傷害(掉落傷害);
        }
    }
}
