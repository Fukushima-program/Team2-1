using UnityEngine;

public class WaterWheel : MonoBehaviour
{
    public bool spin = false;

    private float spinSpeed = -150.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spin)
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }
    }
}
