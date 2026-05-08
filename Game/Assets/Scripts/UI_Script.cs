using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{

    public int StageNumber = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {

        if (StageNumber == 0)
        {
            SceneManager.LoadScene("GameScene");
        }

        else if(StageNumber == 1)
        {
            SceneManager.LoadScene("GameScene2");
        }
    
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
