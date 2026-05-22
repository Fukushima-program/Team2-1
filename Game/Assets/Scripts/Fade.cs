using UnityEngine;

public class Fade : MonoBehaviour
{
    private Renderer rend;
    private short isreversed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend=GetComponent<Renderer>();
        rend.sharedMaterial.color = Color.black;
        isreversed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (isreversed)
        {
            case 1:
                if (rend.sharedMaterial.color.a >= 0)
                {
                    Color c = rend.sharedMaterial.color;
                    c.a -= 0.02f * isreversed;
                    rend.sharedMaterial.color = c;
                    Debug.Log("moving");
                }
                break;
            case -1:
                if (rend.sharedMaterial.color.a <= 1)
                {
                    Color c = rend.sharedMaterial.color;
                    c.a -= 0.02f * isreversed;
                    rend.sharedMaterial.color = c;
                    Debug.Log("moving");
                }
                break;
        }
        /*if (rend.sharedMaterial.color.a > 0)
        {
            Color c = rend.sharedMaterial.color;
            c.a -= 0.02f*isreversed;
            rend.sharedMaterial.color = c;
            Debug.Log("moving");
        }*/
    }

    public void Reverse()
    {
        isreversed *= -1;
    }
}
