using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Slider ��q�p;
    public float HP;
    void Start()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ����(float i)
    {
        HP -= i;
        ��q�p.value = HP;
        if (HP <= 0)
        {
            SceneManager.LoadScene("���`");
        }
    }
    public void �[��(float i)
    {
        HP += i;
        ��q�p.value = HP;

    }

    public void �]�w��q(float i)
    {
        HP = i;
        ��q�p.value = HP;
    }
}
