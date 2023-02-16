using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Boss : 怪物總控制
{
    [SerializeField] Slider 血量條;
    float hp = 800;
    public Transform player;
    public Transform Monster;
    public Animator 怪物動畫;
    public Animator 黑幕;
    public Flowchart 對話;
    public enum 狀態機 {一般 , 變身中, 憤怒};
    public 狀態機 怪物狀態;
    //public bool isFlipped = false;
    public void LookatPlayer(){  //轉向
        //Vector3 flipped = player.transform.localScale;
        //flipped.z *= -1f;

        if(transform.position.x > player.position.x )
        {
            Monster.transform.localScale = new Vector3(1,1,1);
            //transform.Rotate(0f , 180f , 0f);
            //isFlipped = false;
        }
        else if(transform.position.x < player.position.x )
        {
            Monster.transform.localScale = new Vector3(-1, 1, 1); ;
            //transform.Rotate(0f , 180f , 0f);
            //isFlipped = true;

        }

    }
    public override void 受傷害(float 損傷值)
    {
        if (怪物狀態 == Boss.狀態機.變身中) {
            return;
        }

        hp -= 損傷值;
        血量條.value = hp;
        if (hp <=400 && 怪物狀態 == Boss.狀態機.一般) {
            怪物狀態 = 狀態機.變身中;
            怪物動畫.SetTrigger("Mad");
        
        }

        if (hp <= 0)
        {
            對話.SetBooleanVariable("魔王死亡",true);          
            Destroy(血量條.gameObject.GetComponentInParent<Canvas>().gameObject);
            this.gameObject.SetActive(false);
            
            
        }


        // Debug.Log(hp);
    }

    public void 死亡對話完畢() {
        黑幕.gameObject.SetActive(true);
        黑幕.SetBool("漸深", true);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("collision.tag" + collision.tag);
        if (collision.gameObject.CompareTag("Player")) {
            print("collision.tag"+ collision.tag);
            collision.GetComponent<player>().受傷害(10,this.gameObject.transform); 
         }
    }
}
