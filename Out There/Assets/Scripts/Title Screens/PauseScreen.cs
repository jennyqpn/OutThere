using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
