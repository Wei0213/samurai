using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Boss : �Ǫ��`����
{
    [SerializeField] Slider ��q��;
    float hp = 800;
    public Transform player;
    public Transform Monster;
    public Animator �Ǫ��ʵe;
    public Animator �¹�;
    public Flowchart ���;
    public enum ���A�� {�@�� , �ܨ���, ����};
    public ���A�� �Ǫ����A;
    //public bool isFlipped = false;
    public void LookatPlayer(){  //��V
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
    public override void ���ˮ`(float �l�˭�)
    {
        if (�Ǫ����A == Boss.���A��.�ܨ���) {
            return;
        }

        hp -= �l�˭�;
        ��q��.value = hp;
        if (hp <=400 && �Ǫ����A == Boss.���A��.�@��) {
            �Ǫ����A = ���A��.�ܨ���;
            �Ǫ��ʵe.SetTrigger("Mad");
        
        }

        if (hp <= 0)
        {
            ���.SetBooleanVariable("�]�����`",true);          
            Destroy(��q��.gameObject.GetComponentInParent<Canvas>().gameObject);
            this.gameObject.SetActive(false);
            
            
        }


        // Debug.Log(hp);
    }

    public void ���`��ܧ���() {
        �¹�.gameObject.SetActive(true);
        �¹�.SetBool("���`", true);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("collision.tag" + collision.tag);
        if (collision.gameObject.CompareTag("Player")) {
            print("collision.tag"+ collision.tag);
            collision.GetComponent<player>().���ˮ`(10,this.gameObject.transform); 
         }
    }
}
