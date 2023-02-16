using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float dieTime, damage;
   
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().¨ü¶Ë®`(damage);
        }
        Die();
    }
    IEnumerator CountDownTimer() {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    void Die() {
        Destroy(gameObject);
    }

    
}
