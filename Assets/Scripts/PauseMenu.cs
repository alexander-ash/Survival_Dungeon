using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    
    

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    void OnPause (InputValue value)// not working, for test purposes
    {
        if (value.isPressed)
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    private void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<PlayerController>().doYouOnPause(GameIsPaused);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ByeBye");
    }
}
