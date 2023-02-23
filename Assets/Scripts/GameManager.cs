using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Slider 血量計;
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

    public void 扣血(float i)
    {
        HP -= i;
        血量計.value = HP;
        if (HP <= 0)
        {
            SceneManager.LoadScene("死亡");
        }
    }
    public void 加血(float i)
    {
        HP += i;
        血量計.value = HP;

    }

    public void 設定血量(float i)
    {
        HP = i;
        血量計.value = HP;
    }
}
