using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : �Ǫ��`����
{
    Rigidbody2D �p������;
    SpriteRenderer �p���Ϲ�;
    bool �¥�=false;
    
    [SerializeField] Slider ��q��;
    // Start is called before the first frame update
    [Header("��¦�ƭ�")]
    public float hp;
    public float �p���ˮ`;
    void Start()
    {
        �p������ = GetComponent<Rigidbody2D>();
        �p���Ϲ� = GetComponent<SpriteRenderer>();
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        ����();
    }

    private void ����()
    {
        �¥�= �p���Ϲ�.flipX;
        if (�¥�)
        {
            �p������.velocity = Vector2.left;
        }
        else {
            �p������.velocity = Vector2.right;
        }
        
    }
    public override void ���ˮ`(float �l�˭�) {
        //print("�p���l�˭�:" + �l�˭�);
        hp -= �l�˭�*0.8f;
        ��q��.value = hp;
        if (hp < 0) {
            Destroy(gameObject);
        }
       // Debug.Log(hp);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("��V");
        if (�¥�)
        {
            �p���Ϲ�.flipX = false;
        }
        else {
            �p���Ϲ�.flipX = true;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<player>().���ˮ`(�p���ˮ`);
        }
        
    }
    
}
