using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public GameObject CurveWater;
    public GameObject StraightWater;
    public bool test = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurveWater.SetActive(true);
        StraightWater.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            CurveWater.SetActive(false);
            StraightWater.SetActive(true);
        }
    }

    public void StopFlow()
    {
        CurveWater.SetActive(false);
        StraightWater.SetActive(true);
    }
}
