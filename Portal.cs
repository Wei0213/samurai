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
        ����Manager.�����������_�ǰe��();
        SceneManager.LoadScene(sceneName);
    }
}
