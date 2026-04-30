using UnityEngine;

public class FloorSpin : MonoBehaviour
{
    public float spinSpeed = 0.0f;
    public bool isSpinning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpinning)
        {
            transform.Rotate(Vector3.forward * -spinSpeed * Time.deltaTime);
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    public void StopSpin()
    {
        isSpinning = false;
    }
}
