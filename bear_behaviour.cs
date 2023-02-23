using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bear_behaviour : ©Çª«Á`±±¨î
{
    #region Public Variables
    [Header("¨µÅÞ½d³ò")]
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    [Header("§ðÀ»§N«o®É¶¡")]
    public float timer;
    [Header("¨µÅÞ°Ï")]
    public Transform leftLimit;
    public Transform rightLimit;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    [Header("ª±®a")]
    private bool inRange;//ª±®a½d³ò
    private bool cooling;//¬O§_©Çª«§ðÀ»§N«o
    private float intTimer;
    [Header("¦å¶q")]
    public float hp;
    public float ºµºµ¶Ë®`;
    [SerializeField] Slider ¦å¶q±ø;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("headattack"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
            
        }
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            StopAttack();
        }
    }

    
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Attack()
    {
        SelectTarget();
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack",false);

    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("headattack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void RaycastDebugger() 
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right* rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
            inRange = true;
            Flip();
        }
    }
    public void TriggerCooling() {
        cooling = true;
    }
    void Cooldown() {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode) {
            cooling = false;
            timer = intTimer;
        }
    }
    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    private void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180;
        }
        else
        {
            //Debug.Log("Twist");
            rotation.y = 0;
        }

        transform.eulerAngles = rotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().¨ü¶Ë®`(ºµºµ¶Ë®`);
        }
    }
    public override void ¨ü¶Ë®`(float ·l¶Ë­È)
    {
        //print("ºµºµ·l¶Ë­È:" + ·l¶Ë­È);
        hp -= ·l¶Ë­È * 0.6f;
        ¦å¶q±ø.value = hp;
        if (hp < 0)
        {
            Destroy(gameObject);
        }
        // Debug.Log(hp);
    }

    public void ¶¯§q­µ®Ä() {
        ­µ®ÄManager.¼½©ñ©Çª«­µ®Ä_ºµ§q();
    }
}
