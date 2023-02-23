using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : 怪物總控制
{
    Rigidbody2D 小紅剛體;
    SpriteRenderer 小紅圖像;
    bool 朝左=false;
    
    [SerializeField] Slider 血量條;
    // Start is called before the first frame update
    [Header("基礎數值")]
    public float hp;
    public float 小紅傷害;
    void Start()
    {
        小紅剛體 = GetComponent<Rigidbody2D>();
        小紅圖像 = GetComponent<SpriteRenderer>();
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        移動();
    }

    private void 移動()
    {
        朝左= 小紅圖像.flipX;
        if (朝左)
        {
            小紅剛體.velocity = Vector2.left;
        }
        else {
            小紅剛體.velocity = Vector2.right;
        }
        
    }
    public override void 受傷害(float 損傷值) {
        //print("小紅損傷值:" + 損傷值);
        hp -= 損傷值*0.8f;
        血量條.value = hp;
        if (hp < 0) {
            Destroy(gameObject);
        }
       // Debug.Log(hp);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("轉向");
        if (朝左)
        {
            小紅圖像.flipX = false;
        }
        else {
            小紅圖像.flipX = true;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<player>().受傷害(小紅傷害);
        }
        
    }
    
}
