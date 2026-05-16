using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public GameObject CurveWater;
    public GameObject StraightWater;

    private WorldSE se;
    public Transform waterPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        se = GetComponent<WorldSE>();
        CurveWater.SetActive(true);
        StraightWater.SetActive(false);

        waterPoint.position = CurveWater.transform.position;
        se.Play(AudioManager.Instance.waterSE, true);
    }

    public void StopFlow()
    {
        CurveWater.SetActive(false);
        StraightWater.SetActive(true);
        waterPoint.position = StraightWater.transform.position;
    }
}
