using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject Pause_Screen;

    public Transform player;

    private void Update()
    {
        Load_Pause();
        Restart();
    }

    void Start()
    {
        Load_Data();
    }

    public void Load_Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Screen.SetActive(true);
        }
    }

    private void Load_Data()
    {
        Vector3 position = Vector3.zero;
        position.x = PlayerPrefs.GetFloat("PosX",player.position.x);
        position.y = PlayerPrefs.GetFloat("PosY",player.position.y);
        position.z = PlayerPrefs.GetFloat("PosZ", player.position.z);
        player.position = position;
    }

    private void Reset_Data()
    {
        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosY", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset_Data();
            SceneManager.LoadScene(1);
        }
    }

}
