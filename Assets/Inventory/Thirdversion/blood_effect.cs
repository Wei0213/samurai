using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class blood_effect : MonoBehaviour
{
    private player ���a;
    public float healthBoost;
    
    private void Start()
    {
        ���a = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    public void Use()
    {
        ����Manager.����D������_���Ĥ�();
        GameManager.instance.�[��(10);
        Debug.Log("10");
        Destroy(gameObject);
        //GameManager.instance.HP += 100;
    }

}
