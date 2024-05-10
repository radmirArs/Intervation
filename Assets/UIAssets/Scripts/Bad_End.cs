using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bad_End : MonoBehaviour
{
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

    }

    public void Load_Main_menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
