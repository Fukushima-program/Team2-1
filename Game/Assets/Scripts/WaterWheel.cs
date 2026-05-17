using UnityEngine;

public class WaterWheel : MonoBehaviour
{
    public bool spin = false;


    private float spinSpeed = -150.0f;
    public GameObject elektype;
    private Elek elek;

    private WorldSE se;
    private bool sePlaying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spin)
        {
            if (!sePlaying)
            {
                se.Play(AudioManager.Instance.waterWheelSE, true);
                sePlaying = true;
            }
            transform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
            elek = elektype.GetComponent<Elek>();
            if (elek == null)
            {
                return;
            }
            elek.isElektric = true;
        }
    }
}
