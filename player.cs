using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    CapsuleCollider2D 玩家身體碰撞器;
    BoxCollider2D 玩家腳步碰撞器;//coll
    Rigidbody2D 玩家剛體;//rb
    SpriteRenderer 角色圖像;
    Transform 角色方位;
    bool 射擊方向;
    Animator 動畫控制器;//anim
    [Header("玩家數值")]
    public float 移動速度 = 7.0f;
    [SerializeField] float 跳躍力量 = 500.0f;//jumpForce
    bool 可移動 = true;
    public float 攻擊加成 = 1;
    //bool 正受傷 = true;
    [SerializeField] float 飛出距離 = 500.0f;


    bool isGround, isJump;
    [Header("地板")]
    [SerializeField] Transform groundCheck;
    public LayerMask 平台;//二段跳

    public GameObject myBag;//包包
    //bool isOpen;

    bool jumpPressed;
    int jumpCount;

    public float HP = 100;
    [SerializeField] Slider 血量計;

    public bool 可攻擊;
    [SerializeField] Vector3 攻位移;
    [SerializeField] float 攻範圍;
    [SerializeField] LayerMask 判定圖層;
    //save
    Vector3 position;

    [Header("攻擊效果")]
    [SerializeField] GameObject 攻擊效果;
    [SerializeField] GameObject 攻擊點;

    [Header("防護罩")]
    [SerializeField] GameObject shield;
    bool shielded;
    public float 冷卻時間;
    float 最後使用時間 = -100;


    // Start is called before the first frame update
    void Start()
    {
        玩家身體碰撞器 = GetComponent<CapsuleCollider2D>();
        玩家腳步碰撞器 = GetComponent<BoxCollider2D>();
        玩家剛體 = GetComponent<Rigidbody2D>();
        角色圖像 = GetComponent<SpriteRenderer>();
        動畫控制器 = GetComponent<Animator>();
        角色方位 = GetComponent<Transform>();
        血量計.value = HP;
        shielded = false;//盾牌
    }


    // Update is called once per frame
    void Update()
    {

        if (!動畫控制器.GetBool("受傷"))
        {
            移動();
        }
        //受傷();
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;

        }
        //openMyBag();//包包
        攻擊();
        MoveController();
        CheckShield();

    }

    private void 攻擊()
    {
        //if (!可攻擊)
        // return;
        if (Input.GetKeyDown(KeyCode.J))
        {
            動畫控制器.SetTrigger("攻擊");
        }
    }
    public void 攻擊判定()
    {
        //攻擊位置的設定點
        Vector3 攻擊位置 = transform.position;
        if (角色方位.localScale.x > 0)
            攻擊位置 += transform.right * 攻位移.x;
        else
            攻擊位置 += transform.right * -攻位移.x;
        Collider2D 被撞物 = Physics2D.OverlapCircle(攻擊位置, 攻範圍, 判定圖層);
        if (被撞物 != null)
        {
            //音源.PlayOneShot(音效檔[3]);
            //攻擊點.transform.position = 被撞物.transform.position + Vector3.up*3f;
            //Instantiate(攻擊效果, 攻擊點.transform);
            if (被撞物.gameObject.tag == "怪物")
            {
                Debug.Log("攻擊到");
                被撞物.GetComponent<怪物總控制>().受傷害(30 + 攻擊加成);
            }
            if (被撞物.gameObject.tag == "魔王")
            {
                Debug.Log("攻擊到魔王");
                被撞物.GetComponentInParent<怪物總控制>().受傷害(30);
            }

        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, 平台);
        跳();

    }

    /*private void 受傷()
    {

        if (玩家身體碰撞器.IsTouchingLayers(LayerMask.GetMask("敵人")) || 玩家腳步碰撞器.IsTouchingLayers(LayerMask.GetMask("敵人"))) {
            //插動畫
            正受傷 = true;
            動畫控制器.SetTrigger("受傷");
            //彈開
            if (角色圖像.flipX == false) //right
            {
                
                玩家剛體.AddForce(Vector2.left * 500f, ForceMode2D.Force);
            }
            else {
                玩家剛體.AddForce(Vector2.right * 500f, ForceMode2D.Force);
            }

            //受傷音效
            //扣血
            GameManager.instance.扣血(1);
            //扣血(1);
            //StartCoroutine(受傷硬直());
        }

    }*/

    /* IEnumerator 受傷硬直()
     {
         yield return new WaitForSeconds(0.3f);
         動畫控制器.SetBool("受傷", false);

         yield return new WaitForSeconds(0.4f);
         正受傷 = false;
     }
    */
    /*public void 扣血(int 損害值)
    {
        //GameManager.instance.HP -= 損害值;

        HP -= 損害值;
        //bug.Log(HP);
        血量計.value = HP;
        if (HP < 0) {
            Debug.Log("death");
        }
    }*/



    private void 跳()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if (isGround && jumpPressed)
        {
            isJump = true;
            玩家剛體.velocity = new Vector2(玩家剛體.velocity.x, 跳躍力量);
            jumpCount--;
            jumpPressed = false;
            動畫控制器.SetBool("跳", true);
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            玩家剛體.velocity = new Vector2(玩家剛體.velocity.x, 跳躍力量);
            jumpCount--;
            jumpPressed = false;
            動畫控制器.SetBool("跳", true);
        }
        /*if (Input.GetButtonDown("Jump")&&jumpCount>0) {
            玩家剛體.AddForce(Vector2.up*跳躍力量);
            動畫控制器.SetBool("跳", true);
            
            jumpCount--;
        }*/
    }

    private void 移動()
    {
        if (!可移動)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        玩家剛體.velocity = new Vector2(h * 移動速度, 玩家剛體.velocity.y);

        if (h > 0)//朝右
        {
            //角色圖像.flipX = false;
            角色方位.localScale = new Vector2(1.574656f, 角色方位.localScale.y);


            動畫控制器.SetBool("走路", true);
        }
        else if (h < 0)//朝左
        {
            //角色圖像.flipX = true;

            角色方位.localScale = new Vector2(-1.574656f, 角色方位.localScale.y);
            動畫控制器.SetBool("走路", true);
        }
        else//閒置
        {
            動畫控制器.SetBool("走路", false);
        }
    }
    public void 移動音效()
    {
        音效Manager.播放主角音效_走路();
    }
    public void 攻擊音效()
    {
        音效Manager.播放主角音效_揮刀();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (玩家腳步碰撞器.IsTouchingLayers(LayerMask.GetMask("平台")))
            動畫控制器.SetBool("跳", false);
        if (collision.gameObject.tag == "怪物")
        {
            if (!shielded)
            {
                if (transform.position.x < collision.transform.position.x)
                {
                    玩家剛體.AddForce(Vector2.left * 飛出距離, ForceMode2D.Force);
                    動畫控制器.SetBool("受傷", true);
                }
                else if (transform.position.x > collision.transform.position.x)
                {
                    玩家剛體.AddForce(Vector2.right * 飛出距離, ForceMode2D.Force);
                    動畫控制器.SetBool("受傷", true);
                }

                //音效Manager.播放主角音效_受傷();
            }
            //GameManager.instance.扣血(5);
        }

    }

    public void 受傷害(float 損傷值)
    {
        if (!shielded)
        {


            GameManager.instance.扣血(損傷值);
        }
    }
    public void 受傷害(float 損傷值, Transform coll)
    {
        if (transform.position.x < coll.transform.position.x)
        {
            玩家剛體.AddForce(Vector2.left * 飛出距離 / 4, ForceMode2D.Force);
            動畫控制器.SetBool("受傷", true);
        }
        else if (transform.position.x > coll.transform.position.x)
        {
            玩家剛體.AddForce(Vector2.right * 飛出距離 / 4, ForceMode2D.Force);
            動畫控制器.SetBool("受傷", true);
        }
        GameManager.instance.扣血(損傷值);
    }
    /*void openMyBag() {
        if (Input.GetKeyDown(KeyCode.O)) {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
    */

    //pan_save_load_newplayer
    public void SavePlayer()
    {
        Saveload.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = Saveload.LoadPlayer();
        //level = data.level;
        HP = data.HP;


        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }

    public void newPlayer()
    {
        HP = 100;

        position.x = (float)-5.7707;
        position.y = (float)-1.2097;
        position.z = 0;

    }

    //沒有對話可移動
    void MoveController()
    {
        if (Talkable.isTalking)
        {
            玩家剛體.Sleep();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            collision.gameObject.transform.GetComponent<Portal>().changeScene();
        }
    }

    //是否護盾
    void CheckShield()
    {

        if (冷卻時間 + 最後使用時間 >= Time.time)
            return;

        if (Input.GetKeyDown(KeyCode.L) && !shielded)
        {
            最後使用時間 = Time.time;
            shield.SetActive(true);
            shielded = true;
            //GetComponent<Animator>().SetTrigger("護盾");
            //持續時間
            Invoke("NoShield", 3f);
        }
    }
    void NoShield()
    {
        shield.SetActive(false);
        shielded = false;

    }

}
