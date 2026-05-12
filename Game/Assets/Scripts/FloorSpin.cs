using UnityEngine;

public class FloorSpin : MonoBehaviour
{
    public float spinSpeed = 0.0f;
    //public bool isSpinning = false;

    private Elek elek;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = this.GetComponent<Elek>();
    }

    // Update is called once per frame
    void Update()
    {
        if (elek == null) return;

        if (elek.isConnected)
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }

    }

    //public void StartSpin()
    //{
    //    isSpinning = true;
    //}

    //public void StopSpin()
    //{
    //    isSpinning = false;
    //}
}
