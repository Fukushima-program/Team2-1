using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    private UI_Script ui;

    private WorldSE se;

    private int timer;

    public Fade fade;

    void Start()
    {
        timer = -1;
        ui = FindAnyObjectByType<UI_Script>();  
        se = GetComponent<WorldSE>();
        fade=fade.GetComponent<Fade>();
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

    private void Update()
    {
        if (timer >= 0)
        {
            timer--;
            if (timer < 0) {
                ui.Load("Clear");
            }
        }
    }

    private void Goal()
    {
        timer = 80;
        fade.Reverse();
    }

}
