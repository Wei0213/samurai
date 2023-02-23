using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    CapsuleCollider2D ���a����I����;
    BoxCollider2D ���a�}�B�I����;//coll
    Rigidbody2D ���a����;//rb
    SpriteRenderer ����Ϲ�;
    Transform ������;
    bool �g����V;
    Animator �ʵe���;//anim
    [Header("���a�ƭ�")]
    public float ���ʳt�� = 7.0f;
    [SerializeField] float ���D�O�q = 500.0f;//jumpForce
    bool �i���� = true;
    public float �����[�� = 1;
    //bool ������ = true;
    [SerializeField] float ���X�Z�� = 500.0f;


    bool isGround, isJump;
    [Header("�a�O")]
    [SerializeField] Transform groundCheck;
    public LayerMask ���x;//�G�q��

    public GameObject myBag;//�]�]
    //bool isOpen;

    bool jumpPressed;
    int jumpCount;

    public float HP = 100;
    [SerializeField] Slider ��q�p;

    public bool �i����;
    [SerializeField] Vector3 ��첾;
    [SerializeField] float ��d��;
    [SerializeField] LayerMask �P�w�ϼh;
    //save
    Vector3 position;

    [Header("�����ĪG")]
    [SerializeField] GameObject �����ĪG;
    [SerializeField] GameObject �����I;

    [Header("���@�n")]
    [SerializeField] GameObject shield;
    bool shielded;
    public float �N�o�ɶ�;
    float �̫�ϥήɶ� = -100;


    // Start is called before the first frame update
    void Start()
    {
        ���a����I���� = GetComponent<CapsuleCollider2D>();
        ���a�}�B�I���� = GetComponent<BoxCollider2D>();
        ���a���� = GetComponent<Rigidbody2D>();
        ����Ϲ� = GetComponent<SpriteRenderer>();
        �ʵe��� = GetComponent<Animator>();
        ������ = GetComponent<Transform>();
        ��q�p.value = HP;
        shielded = false;//�޵P
    }


    // Update is called once per frame
    void Update()
    {

        if (!�ʵe���.GetBool("����"))
        {
            ����();
        }
        //����();
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;

        }
        //openMyBag();//�]�]
        ����();
        MoveController();
        CheckShield();

    }

    private void ����()
    {
        //if (!�i����)
        // return;
        if (Input.GetKeyDown(KeyCode.J))
        {
            �ʵe���.SetTrigger("����");
        }
    }
    public void �����P�w()
    {
        //������m���]�w�I
        Vector3 ������m = transform.position;
        if (������.localScale.x > 0)
            ������m += transform.right * ��첾.x;
        else
            ������m += transform.right * -��첾.x;
        Collider2D �Q���� = Physics2D.OverlapCircle(������m, ��d��, �P�w�ϼh);
        if (�Q���� != null)
        {
            //����.PlayOneShot(������[3]);
            //�����I.transform.position = �Q����.transform.position + Vector3.up*3f;
            //Instantiate(�����ĪG, �����I.transform);
            if (�Q����.gameObject.tag == "�Ǫ�")
            {
                Debug.Log("������");
                �Q����.GetComponent<�Ǫ��`����>().���ˮ`(30 + �����[��);
            }
            if (�Q����.gameObject.tag == "�]��")
            {
                Debug.Log("�������]��");
                �Q����.GetComponentInParent<�Ǫ��`����>().���ˮ`(30);
            }

        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ���x);
        ��();

    }

    /*private void ����()
    {

        if (���a����I����.IsTouchingLayers(LayerMask.GetMask("�ĤH")) || ���a�}�B�I����.IsTouchingLayers(LayerMask.GetMask("�ĤH"))) {
            //���ʵe
            ������ = true;
            �ʵe���.SetTrigger("����");
            //�u�}
            if (����Ϲ�.flipX == false) //right
            {
                
                ���a����.AddForce(Vector2.left * 500f, ForceMode2D.Force);
            }
            else {
                ���a����.AddForce(Vector2.right * 500f, ForceMode2D.Force);
            }

            //���˭���
            //����
            GameManager.instance.����(1);
            //����(1);
            //StartCoroutine(���˵w��());
        }

    }*/

    /* IEnumerator ���˵w��()
     {
         yield return new WaitForSeconds(0.3f);
         �ʵe���.SetBool("����", false);

         yield return new WaitForSeconds(0.4f);
         ������ = false;
     }
    */
    /*public void ����(int �l�`��)
    {
        //GameManager.instance.HP -= �l�`��;

        HP -= �l�`��;
        //bug.Log(HP);
        ��q�p.value = HP;
        if (HP < 0) {
            Debug.Log("death");
        }
    }*/



    private void ��()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if (isGround && jumpPressed)
        {
            isJump = true;
            ���a����.velocity = new Vector2(���a����.velocity.x, ���D�O�q);
            jumpCount--;
            jumpPressed = false;
            �ʵe���.SetBool("��", true);
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            ���a����.velocity = new Vector2(���a����.velocity.x, ���D�O�q);
            jumpCount--;
            jumpPressed = false;
            �ʵe���.SetBool("��", true);
        }
        /*if (Input.GetButtonDown("Jump")&&jumpCount>0) {
            ���a����.AddForce(Vector2.up*���D�O�q);
            �ʵe���.SetBool("��", true);
            
            jumpCount--;
        }*/
    }

    private void ����()
    {
        if (!�i����)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        ���a����.velocity = new Vector2(h * ���ʳt��, ���a����.velocity.y);

        if (h > 0)//�¥k
        {
            //����Ϲ�.flipX = false;
            ������.localScale = new Vector2(1.574656f, ������.localScale.y);


            �ʵe���.SetBool("����", true);
        }
        else if (h < 0)//�¥�
        {
            //����Ϲ�.flipX = true;

            ������.localScale = new Vector2(-1.574656f, ������.localScale.y);
            �ʵe���.SetBool("����", true);
        }
        else//���m
        {
            �ʵe���.SetBool("����", false);
        }
    }
    public void ���ʭ���()
    {
        ����Manager.����D������_����();
    }
    public void ��������()
    {
        ����Manager.����D������_���M();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (���a�}�B�I����.IsTouchingLayers(LayerMask.GetMask("���x")))
            �ʵe���.SetBool("��", false);
        if (collision.gameObject.tag == "�Ǫ�")
        {
            if (!shielded)
            {
                if (transform.position.x < collision.transform.position.x)
                {
                    ���a����.AddForce(Vector2.left * ���X�Z��, ForceMode2D.Force);
                    �ʵe���.SetBool("����", true);
                }
                else if (transform.position.x > collision.transform.position.x)
                {
                    ���a����.AddForce(Vector2.right * ���X�Z��, ForceMode2D.Force);
                    �ʵe���.SetBool("����", true);
                }

                //����Manager.����D������_����();
            }
            //GameManager.instance.����(5);
        }

    }

    public void ���ˮ`(float �l�˭�)
    {
        if (!shielded)
        {


            GameManager.instance.����(�l�˭�);
        }
    }
    public void ���ˮ`(float �l�˭�, Transform coll)
    {
        if (transform.position.x < coll.transform.position.x)
        {
            ���a����.AddForce(Vector2.left * ���X�Z�� / 4, ForceMode2D.Force);
            �ʵe���.SetBool("����", true);
        }
        else if (transform.position.x > coll.transform.position.x)
        {
            ���a����.AddForce(Vector2.right * ���X�Z�� / 4, ForceMode2D.Force);
            �ʵe���.SetBool("����", true);
        }
        GameManager.instance.����(�l�˭�);
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

    //�S����ܥi����
    void MoveController()
    {
        if (Talkable.isTalking)
        {
            ���a����.Sleep();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            collision.gameObject.transform.GetComponent<Portal>().changeScene();
        }
    }

    //�O�_�@��
    void CheckShield()
    {

        if (�N�o�ɶ� + �̫�ϥήɶ� >= Time.time)
            return;

        if (Input.GetKeyDown(KeyCode.L) && !shielded)
        {
            �̫�ϥήɶ� = Time.time;
            shield.SetActive(true);
            shielded = true;
            //GetComponent<Animator>().SetTrigger("�@��");
            //����ɶ�
            Invoke("NoShield", 3f);
        }
    }
    void NoShield()
    {
        shield.SetActive(false);
        shielded = false;

    }

}
