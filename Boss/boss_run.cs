using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackrange = 5f;
    public Transform player;
    
    Rigidbody2D rb;
    Boss boss�}��;

    [Header("�����N�o")]
    public float �@��Ҧ������N�o�ɶ�;
    float �̫�ϥΤ@������ɶ�;

    public float ����Ҧ������N�o�ɶ�;
    float �̫�ϥμ�������ɶ�;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        rb = animator.GetComponentInParent<Rigidbody2D>();
        boss�}�� = animator.GetComponentInParent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss�}��.LookatPlayer();
        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        Debug.Log("�Ǫ����A:" + boss�}��.�Ǫ����A); 
      
        if (Vector2.Distance(player.position, rb.position) <= attackrange )  //�P�w�����d��
        {
            if (boss�}��.�Ǫ����A == Boss.���A��.�@��  && �@��Ҧ������N�o�ɶ�+ �̫�ϥΤ@������ɶ�<Time.time)  //�@��Ҧ�
            {
                �̫�ϥΤ@������ɶ� = Time.time;
                animator.SetTrigger("Attack");
            }
            else if (boss�}��.�Ǫ����A == Boss.���A��.����  && ����Ҧ������N�o�ɶ�+ �̫�ϥμ�������ɶ� < Time.time)
            {   //����Ҧ�
                �̫�ϥμ�������ɶ� = Time.time;
                speed = 5;
                //�H���X��
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
