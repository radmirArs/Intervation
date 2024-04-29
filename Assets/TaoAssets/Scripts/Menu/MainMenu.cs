using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FirstPersonLook Player;
    public GameObject _MainMenu;
    bool isMenu = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameMenuButton();
        }
    }
    public void GameMenuButton() {
        if (!isMenu) { 
                Time.timeScale = 0;
                Player.sensitivity = 0;
                _MainMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isMenu = true;
            }
            else {
                GameContinueButton();
            }
    }
    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameMainButton() {
        SceneManager.LoadScene(2);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
    public void GameContinueButton() {
        isMenu = false;
        Time.timeScale = 1f;
        Player.sensitivity = 2f;
        _MainMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
