using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Transform player;

    [SerializeField] GameObject GameplayUI;

    void OnEnable()
    {
        Set_Time_on_Pause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameplayUI.SetActive(true);

    }

    private void Set_Time_on_Pause()
    {
        Time.timeScale = 0f;
        GameplayUI.SetActive(false);
    }

    private void Set_Time_on_Play()
    {
        Time.timeScale = 1f;
        GameplayUI.SetActive(true);
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
