using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    int currentScene;
    public string sceneName;
    void Start()
    {
        currentScene=SceneManager.GetActiveScene().buildIndex;
        �������İ���(currentScene);
        //Debug.Log(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextScene(){
        SceneManager.LoadScene(currentScene+1);
        �������İ���(currentScene + 1);
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
        int i = SceneManager.GetActiveScene().buildIndex;
        �������İ���(i);
    }
    public void ��l�ƹC��() {
        GameManager.instance.�]�w��q(100);
    }


    void �������İ���(int �����s��) {
        switch(�����s��)
        {
            case 0:
                ����Manager.����I������_�ʭ�();
                break;
            case 1:
                ����Manager.����I������_�˪L();
                break;
        }
    }
}
