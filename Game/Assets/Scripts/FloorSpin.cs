using UnityEngine;

public class FloorSpin : MonoBehaviour
{
    public float spinSpeed = 0.0f;
    //public bool isSpinning = false;

    private Elek elek;

    private WorldSE se;
    private bool sePlaying = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = GetComponent<Elek>();
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if (elek == null) return;

        if (elek.isConnected)
        {
            if (!sePlaying)
            {
                se.Play(AudioManager.Instance.rollBridgeSE, true);
                sePlaying = true;
            }
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }
        else
        {
            se.Stop();
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
