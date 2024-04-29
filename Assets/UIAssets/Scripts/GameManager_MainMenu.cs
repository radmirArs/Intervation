using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_MainMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    private void Set_Time_on_Play()
    {
        Time.timeScale = 1f;
    }
    void OnEnable()
    {
        Set_Time_on_Pause();

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
        Set_Time_on_Play();
    }
    private void Set_Time_on_Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
