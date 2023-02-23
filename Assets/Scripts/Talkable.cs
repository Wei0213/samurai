using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Talkable : MonoBehaviour
{
    public Flowchart talkFlowchart;
    public string onCollosionEnter;
    public static Flowchart flowchartManager;
    public bool �i���;
    Rigidbody2D playerRigidbody;
     void Awake()
    {
        flowchartManager = GameObject.Find("��ܺ޲z��").GetComponent<Flowchart>();   
        playerRigidbody=FindObjectOfType<player>().GetComponent<Rigidbody2D> ();
    }
    public static bool isTalking {
        get {
            return flowchartManager.GetBooleanVariable("��ܤ�");
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&�i���) {
            playerRigidbody.Sleep();
            Block targetBlock = talkFlowchart.FindBlock(onCollosionEnter);
            talkFlowchart.ExecuteBlock(targetBlock);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            �i��� = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        �i��� = false;
    }

}
