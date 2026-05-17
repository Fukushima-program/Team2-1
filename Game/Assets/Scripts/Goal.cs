using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    private UI_Script ui;

    private WorldSE se;

    void Start()
    {
        ui = FindAnyObjectByType<UI_Script>();  
        se = GetComponent<WorldSE>();
    }
    private void OnTriggerEnter(Collider other)
    {
        se.Play(AudioManager.Instance.goalSE);
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            Goal();
        }

    }
    
    private void Goal()
    {
       ui.Load("Clear");
    }

}
