using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed,shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject Dart;
    
   
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)&&!isShooting) {
            //Shoot
            this.gameObject.GetComponent<Animator>().SetTrigger("�g����");
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot() {

        int direction(){
            SpriteRenderer ���asprite = gameObject.GetComponent<SpriteRenderer>();
            if (gameObject.GetComponent<Transform>().localScale.x<0)   //�Ϲ�flipx����
            {
                return -1;
            }
            else {
                return +1;
            }
            
        }

        ����Manager.����D������_����();
        isShooting = true;
        GameObject newDart = Instantiate(Dart, shootPos.position, Quaternion.identity);
        newDart.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed *direction()* Time.fixedDeltaTime, 0f);
        newDart.transform.localScale = new Vector2(newDart.transform.localScale .x* direction(), newDart.transform.localScale.y);
        Debug.Log("shoot");
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

    }
}
