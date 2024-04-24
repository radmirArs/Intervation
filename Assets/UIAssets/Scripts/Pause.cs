using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
   public void Load_Main_menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Load_Gameplay_Scene()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
