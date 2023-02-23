using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;
    void Start()
    {
        this.transform.tag = "Portal";

    }
    public void changeScene() {
        音效Manager.播放場景音效_傳送門();
        SceneManager.LoadScene(sceneName);
    }
}
