using UnityEngine;

public class Elek : MonoBehaviour
{

    public bool isElektric = false;

    public float ElekTime = 10.0f;

    private float timer = 0.0f;

    void Update()
    {
        if (isElektric)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                PowerOff();
            }
        }
    }


    public void PowerOn()
    {
        isElektric = true;

        timer = ElekTime;
    }

    public void PowerOff()
    {
        isElektric = false;
    }

}
