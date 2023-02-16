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
        場景音效偵測(currentScene);
        //Debug.Log(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextScene(){
        SceneManager.LoadScene(currentScene+1);
        場景音效偵測(currentScene + 1);
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
        int i = SceneManager.GetActiveScene().buildIndex;
        場景音效偵測(i);
    }
    public void 初始化遊戲() {
        GameManager.instance.設定血量(100);
    }


    void 場景音效偵測(int 場景編號) {
        switch(場景編號)
        {
            case 0:
                音效Manager.播放背景音樂_封面();
                break;
            case 1:
                音效Manager.播放背景音樂_森林();
                break;
        }
    }
}
