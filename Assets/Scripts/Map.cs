using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject map;
    public static bool �ݦa��;
    bool isClosed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && �ݦa��)
        {
            isClosed = !isClosed;
            map.SetActive(isClosed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            �ݦa�� = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        �ݦa�� = false;
        map.SetActive(false);
    }
}
