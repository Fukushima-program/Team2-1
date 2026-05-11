using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject elekObject;
    private Elek electric;
    private Elek myElektric;
    private float speed = 50f;
    private float currentZ;
    private bool startLever = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        electric = elekObject.GetComponent<Elek>();
        myElektric = this.GetComponent<Elek>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (myElektric.isElektric && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Works!");
            startLever = true;
        }

        if(startLever) {
            Vector3 rot = transform.eulerAngles;
            currentZ = rot.z;
            if (currentZ > 180) currentZ -= 360;

            currentZ = Mathf.MoveTowards(currentZ, -30f, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(rot.x, rot.y ,currentZ);

            if (currentZ <= -30f)
            {
                startLever = false;
                electric.isElektric = true;
            }
        }
    }
}
