using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject elekObject;
    private Elek electric;
    private Elek myElektric;
    private float speed = 50f;
    private float currentZ;
    private float targetZ;
    private bool startLever = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        electric = elekObject.GetComponent<Elek>();
        myElektric = GetComponent<Elek>();
        targetZ = 30f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (myElektric.isElektric && Input.GetMouseButtonDown(0))
        {
            startLever = true;

            if (targetZ == 30f)
            {
                targetZ = -30f;
            }
            else
            {
                targetZ = 30f;
            }
        }

        if (startLever)
        {
            Vector3 rot = transform.eulerAngles;
            currentZ = rot.z;
            if (currentZ > 180) currentZ -= 360;

            currentZ = Mathf.MoveTowards(currentZ, targetZ, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(rot.x, rot.y, currentZ);

            if (Mathf.Abs(currentZ - targetZ) < 0.1f)
            {
                startLever = false;
                electric.PowerOn();
            }
        }
    }
}
