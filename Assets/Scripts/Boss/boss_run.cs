using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackrange = 5f;
    public Transform player;
    
    Rigidbody2D rb;
    Boss boss腳本;

    [Header("攻擊冷卻")]
    public float 一般模式攻擊冷卻時間;
    float 最後使用一般攻擊時間;

    public float 憤怒模式攻擊冷卻時間;
    float 最後使用憤怒攻擊時間;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        rb = animator.GetComponentInParent<Rigidbody2D>();
        boss腳本 = animator.GetComponentInParent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss腳本.LookatPlayer();
        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        Debug.Log("怪物狀態:" + boss腳本.怪物狀態); 
      
        if (Vector2.Distance(player.position, rb.position) <= attackrange )  //判定攻擊範圍
        {
            if (boss腳本.怪物狀態 == Boss.狀態機.一般  && 一般模式攻擊冷卻時間+ 最後使用一般攻擊時間<Time.time)  //一般模式
            {
                最後使用一般攻擊時間 = Time.time;
                animator.SetTrigger("Attack");
            }
            else if (boss腳本.怪物狀態 == Boss.狀態機.憤怒  && 憤怒模式攻擊冷卻時間+ 最後使用憤怒攻擊時間 < Time.time)
            {   //憤怒模式
                最後使用憤怒攻擊時間 = Time.time;
                speed = 5;
                //隨機出招
                int count = Random.Range(0,2);
                if (count == 0) {
                    animator.SetTrigger("MadAttack1");
                }
                else if(count == 1){
                    animator.SetTrigger("MadAttack2");
                }
                
               
            }

        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.ResetTrigger("Attack");
    }


}
