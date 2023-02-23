using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GamePaused=false;
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            ������s����();
            if (GamePaused)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }    
    }
    public void PlayGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuiitGame() {
        Application.Quit();
    }
    public void UIEnable() {
        //GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void ������s����() {
        ����Manager.�����������_���s();
    }
}