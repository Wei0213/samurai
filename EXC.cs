using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXC : MonoBehaviour
{
    public GameObject save;
    public GameObject load;
    public GameObject New;

    public float keyDelay = 0f;  // 1 second
    private float timePassed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        save.SetActive(false);
        load.SetActive(false);
        New.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if( timePassed >= keyDelay){	
            timePassed = 0f;
            save.SetActive(!save.activeSelf);
            load.SetActive(!load.activeSelf);
            New.SetActive(!New.activeSelf);
      
        }
        
            
        
    }
}
