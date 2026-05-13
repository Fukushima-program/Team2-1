using UnityEngine;

public class CurveWater : MonoBehaviour
{
    public GameObject straightWater;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        straightWater.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopFlow()
    {

    }
}
