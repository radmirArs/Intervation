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

    private void Reset_Data()
    {
        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosY", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
    }

    public void Load_Main_menu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Reset_Data();
    }
}
