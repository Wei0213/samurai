using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDie : MonoBehaviour
{
    public GameObject diePEffect;
    public float dieTime;
    public int 飛鏢傷害;


    void Start()
    {
        StartCoroutine(Timer());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        //偵測碰到非玩家物體
        if (collisionGameObject.tag != "Player")
        {
            //print("飛鏢碰撞:"+ collisionGameObject.tag);
            //偵測打到怪物
            if (collisionGameObject.tag == "怪物")
                collisionGameObject.GetComponent<怪物總控制>().受傷害(飛鏢傷害);
            if (collisionGameObject.tag == "魔王")
                音效Manager.播放場景音效_鋼鐵();

            Die();
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print("asd");
    //    GameObject collisionGameObject = collision.gameObject;
    //    //偵測碰到非玩家物體
    //    if (collisionGameObject.tag != "Player")
    //    {
    //        //print("飛鏢碰撞:"+ collisionGameObject.tag);
    //        //偵測打到怪物
    //        if (collisionGameObject.tag == "怪物")
    //            collisionGameObject.GetComponent<怪物總控制>().受傷害(飛鏢傷害);
    //        print("GameObject collisionGameObject:" + collisionGameObject.name);
    //        Die();
    //    }
    //}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    void Die()
    {
        if (diePEffect != null)
        {
            //Instantiate(diePEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
