using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LevelManagement : MonoBehaviour
{
    public RectTransform[] stages;
    public RectTransform cursor;
    public string[] sceneName;

    public float cursorSpeed = 10f;

    private int currentIndex = 0;
    private int lastStageIndex = 0;
    private Vector3[] originalScale;
    private UI_Script ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = FindFirstObjectByType<UI_Script>();
        originalScale = new Vector3[stages.Length];
        for (int i = 0; i < stages.Length; i++)
        {
            originalScale[i] = stages[i].localScale;
        }
        MoveCursor();
    }

    // Update is called once per frame
    void Update()
    {
        InputMove();
        AnimateSelectedStage();
        CursorFollow();
        SelectStage();
    }

    private void InputMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentIndex == 3)
            {
                currentIndex = lastStageIndex;
            }
        }

        // Go DOWN to title button
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentIndex != 3)
            {
                lastStageIndex = currentIndex;
                currentIndex = 3;
            }
        }

        // Left / Right only for stages
        if (currentIndex != 3)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentIndex++;

                if (currentIndex > 2)
                {
                    currentIndex = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                currentIndex--;

                if (currentIndex < 0)
                {
                    currentIndex = 2;
                }
            }
        }
    }

    private void AnimateSelectedStage()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            if (i == currentIndex)
            {
                float scale = 1.0f + Mathf.Sin(Time.time * 5.0f) * 0.1f;
                stages[i].localScale = originalScale[i] * scale;
            }
            else
            {
                stages[i].localScale = Vector3.Lerp(stages[i].localScale, originalScale[i], Time.deltaTime * cursorSpeed);
            }
        }
    }

    private void CursorFollow()
    {
        //Vector3 targetPos = stages[currentIndex].position;
        cursor.position = Vector3.Lerp(cursor.position, stages[currentIndex].position, Time.deltaTime * cursorSpeed);
    }

    private void MoveCursor()
    {
        cursor.position = stages[currentIndex].position;
    }

    private void SelectStage()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            ui.Load(sceneName[currentIndex]);
        }
    }
}
