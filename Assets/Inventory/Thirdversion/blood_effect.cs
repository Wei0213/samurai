using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class blood_effect : MonoBehaviour
{
    private player 玩家;
    public float healthBoost;
    
    private void Start()
    {
        玩家 = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    public void Use()
    {
        音效Manager.播放主角音效_喝藥水();
        GameManager.instance.加血(10);
        Debug.Log("10");
        Destroy(gameObject);
        //GameManager.instance.HP += 100;
    }

}
