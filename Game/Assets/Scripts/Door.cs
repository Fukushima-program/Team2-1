using UnityEngine;

public class Door : MonoBehaviour
{
    public float minHigh = 0.0f;
    public float maxHigh = 5f;
    private Elek myElectric;
    private float speed = 0.3f;

    private WorldSE se;
    private bool sePlaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myElectric = GetComponent<Elek>();
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myElectric.isElektric) {
            if (!sePlaying)
            {
                se.Play(AudioManager.Instance.doorSE);
                sePlaying = true;
            }
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            float yPos = pos.y;
            yPos = Mathf.Clamp(yPos, minHigh, maxHigh);
            transform.position = new Vector3(pos.x, yPos, pos.z);
            if(yPos>= maxHigh)
            {
                se.Stop();
            }
        }
    }
}
