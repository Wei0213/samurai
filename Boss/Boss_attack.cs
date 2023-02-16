using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{

    public int attackDamage = 20;
    public Vector3 attackOffSet;
    public float attackrange = 0.1f;
    public LayerMask attackmask;
    // Start is called before the first frame update
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos , attackrange , attackmask);
            if(colInfo != null)
            {
                colInfo.GetComponent<player>().受傷害(attackDamage);          
        }
    }
}
