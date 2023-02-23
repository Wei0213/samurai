using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject map;
    public static bool 看地圖;
    bool isClosed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && 看地圖)
        {
            isClosed = !isClosed;
            map.SetActive(isClosed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            看地圖 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        看地圖 = false;
        map.SetActive(false);
    }
}
