using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIenemy : 怪物總控制
{
    public float walkSpeed,range,timeBTWShots,shootSpeed;
    private float distToPlayer;
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn,canShoot;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player,shootPos;
    public GameObject bullet;
    float hp = 100;
    public float 蟲蟲傷害;
    [SerializeField] Slider 血量條;
    public GameObject  掉落物;
    void Start()
    {
        mustPatrol = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer)) {
            Patrol();
        }
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range) {
            if (player.position.x > transform.position.x && transform.localScale.x < 0|| player.position.x < transform.position.x && transform.localScale.x > 0) {
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if(canShoot)
            StartCoroutine(Shoot());
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol) {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }
    void Patrol() {
        if (mustTurn) {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip() {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
    IEnumerator Shoot() {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet= Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }
    public override void 受傷害(float 損傷值)
    {
        hp -= 損傷值*0.7f;
        血量條.value = hp;
        if (hp < 0)
        {
            Destroy(gameObject);
            音效Manager.播放怪物音效_毛毛蟲死掉();
            Instantiate(掉落物,transform.position,Quaternion.identity);
        }
        // Debug.Log(hp);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().受傷害(蟲蟲傷害);
        }
    }
}
