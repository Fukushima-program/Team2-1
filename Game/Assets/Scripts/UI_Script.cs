using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public void Load(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
