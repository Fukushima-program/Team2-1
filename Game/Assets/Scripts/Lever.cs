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
    public PlayerController player;
    private bool sePlaying = false;
    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        electric = elekObject.GetComponent<Elek>();
        myElektric = GetComponent<Elek>();
        se = GetComponent<WorldSE>();
        targetZ = 30f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
    
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (myElektric.isElektric && Input.GetMouseButtonDown(0) && distance < 1.2f)
        {
            startLever = true;

            if(!sePlaying)
            {
                se.Play(AudioManager.Instance.leverSE);
                sePlaying = true;
            }

            if (targetZ == 30f)
            {
                targetZ = -30f;
                electric.PowerOn();
            }
            else
            {
                targetZ = 30f;
                electric.isElektric = false;
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
                se.Stop();
                sePlaying = false;
                startLever = false;
            }
        }
    }
}
