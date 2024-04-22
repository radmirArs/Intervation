using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas _MainMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            _MainMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
    public void GameContinueButton() {
        _MainMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
