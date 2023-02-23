using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Talkable : MonoBehaviour
{
    public Flowchart talkFlowchart;
    public string onCollosionEnter;
    public static Flowchart flowchartManager;
    public bool 可對話;
    Rigidbody2D playerRigidbody;
     void Awake()
    {
        flowchartManager = GameObject.Find("對話管理器").GetComponent<Flowchart>();   
        playerRigidbody=FindObjectOfType<player>().GetComponent<Rigidbody2D> ();
    }
    public static bool isTalking {
        get {
            return flowchartManager.GetBooleanVariable("對話中");
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&可對話) {
            playerRigidbody.Sleep();
            Block targetBlock = talkFlowchart.FindBlock(onCollosionEnter);
            talkFlowchart.ExecuteBlock(targetBlock);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            可對話 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        可對話 = false;
    }

}
