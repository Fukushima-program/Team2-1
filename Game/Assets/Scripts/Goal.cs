using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    private UI_Script ui;

    void Start()
    {
        ui = FindAnyObjectByType<UI_Script>();    
    }
    private void OnTriggerEnter(Collider other)
    {

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
