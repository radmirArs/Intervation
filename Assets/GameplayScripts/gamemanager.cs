using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject Pause_Screen;

    private void Update()
    {
        Load_Pause();
    }

    private void Set_Time_on_Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Load_Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Screen.SetActive(true);
            Set_Time_on_Pause();
        }
    }
}
