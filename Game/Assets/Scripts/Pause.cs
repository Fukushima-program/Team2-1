using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    private WorldSE[] worldSounds;

    void Start()
    {
        worldSounds = FindObjectsByType<WorldSE>(FindObjectsSortMode.None);
        pausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Debug.Log("isResumed");
            }
            else
            {
                PauseGame();
                Debug.Log("isPaused");
            }
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        foreach (WorldSE se in worldSounds)
        {
            se.Pause();
        }
        isPaused = true; 
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        foreach (WorldSE se in worldSounds)
        {
            se.Resume();
        }
        isPaused = false;
    }
}
