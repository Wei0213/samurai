using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 藤蔓傷害 : MonoBehaviour
{
    public float 藤蔓扣血;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().受傷害(藤蔓扣血);
        }
    }
}
