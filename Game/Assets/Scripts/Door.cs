using UnityEngine;

public class Door : MonoBehaviour
{
    private Elek myElectric;
    private float speed = 0.3f;
    private bool startDoor = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myElectric = this.GetComponent<Elek>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myElectric.isElektric)
        {
            startDoor = true;
        }
        if(startDoor) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Vector3 pos = transform.position;
            float yPos = pos.y;
            yPos = Mathf.Clamp(yPos, 0f, 1.6f);
            transform.position = new Vector3(pos.x, yPos, pos.z);
        }
    }
}
