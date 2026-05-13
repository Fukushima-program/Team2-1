using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject stage1;
    public GameObject stage2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage1.SetActive(false);
        stage2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartStage2()
    {
        stage1.SetActive(false);
        stage2.SetActive(true);
    }
}
