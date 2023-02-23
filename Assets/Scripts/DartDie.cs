using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDie : MonoBehaviour
{
    public GameObject diePEffect;
    public float dieTime;
    public int ����ˮ`;


    void Start()
    {
        StartCoroutine(Timer());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        //�����I��D���a����
        if (collisionGameObject.tag != "Player")
        {
            //print("����I��:"+ collisionGameObject.tag);
            //��������Ǫ�
            if (collisionGameObject.tag == "�Ǫ�")
                collisionGameObject.GetComponent<�Ǫ��`����>().���ˮ`(����ˮ`);
            if (collisionGameObject.tag == "�]��")
                ����Manager.�����������_���K();

            Die();
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print("asd");
    //    GameObject collisionGameObject = collision.gameObject;
    //    //�����I��D���a����
    //    if (collisionGameObject.tag != "Player")
    //    {
    //        //print("����I��:"+ collisionGameObject.tag);
    //        //��������Ǫ�
    //        if (collisionGameObject.tag == "�Ǫ�")
    //            collisionGameObject.GetComponent<�Ǫ��`����>().���ˮ`(����ˮ`);
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
