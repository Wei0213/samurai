using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class 怪物Manager : MonoBehaviour
{
    [SerializeField] 怪物Manager 怪物ManagerA;
    public int 怪物數量;
    int count;
    public Flowchart 對話Fungus;
    void Start()
    {
        怪物數量 = 怪物ManagerA.GetComponentsInChildren<怪物總控制>().Length;
        count = 怪物數量;
    }

    // Update is called once per frame
    void Update()
    {
        怪物數量 = 怪物ManagerA.GetComponentsInChildren<怪物總控制>().Length;
        if (怪物數量 != count) {
            怪物數量變化();
        }
        
    }
    void 怪物數量變化() {
        count = 怪物數量;
        if (count <= 0)
        {
            print("怪物死光");
            對話Fungus.SetBooleanVariable("怪物死光", true);
        }
    }
}
