using UnityEngine;

public class Elek : MonoBehaviour
{

    public bool isElektric = false;
    public bool isConnected = false;

    public float ElekTime = 10.0f;

    public float timer = 0.0f;

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
        isConnected = true;

        timer = ElekTime;
    }

    public void Disconnected()
    {
        isConnected = false;
    }

    public void PowerOff()
    {
        isElektric = false;
    }

}
