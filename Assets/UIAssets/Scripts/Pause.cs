using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Transform player;

    void OnEnable()
    {
        Set_Time_on_Pause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void Set_Time_on_Pause()
    {
        Time.timeScale = 0f;
    }

    private void Set_Time_on_Play()
    {
        Time.timeScale = 1f;
    }

    public void Load_Main_menu()
    {
        Save_data();
        SceneManager.LoadScene("MainMenuScene");
    }

    private void Save_data()
    {
        PlayerPrefs.SetFloat("PosX", player.position.x);
        PlayerPrefs.SetFloat("PosY", player.position.y);
        PlayerPrefs.SetFloat("PosZ", player.position.z);

    }

    public void Continue_game()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Set_Time_on_Play();

    }


    
}
