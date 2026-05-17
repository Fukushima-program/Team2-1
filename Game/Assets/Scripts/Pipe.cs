using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float InteractionDis = 2.0f;
    public PlayerController player;
    public GameObject pipe;
    public Rigidbody rb;
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);

    public WaterWheel wheel;
    public WaterFlow water;
    private bool isFollowing = false;
    private bool isConnected = false;

    private WorldSE se;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < InteractionDis && Input.GetMouseButtonDown(0) && !isConnected)
        {
            se.PlayOneShot(AudioManager.Instance.pipeSE);
            rb.useGravity = false;
            isFollowing = true;
        }
        if(Input.GetMouseButtonDown(1))
        {
            rb.useGravity = true;
            isFollowing = false;

            float distance1 = Vector3.Distance(transform.position, pipe.transform.position);
            if(distance1 < 3)
            {
                Vector3 newPos = new Vector3(pipe.transform.position.x + 2f, pipe.transform.position.y, pipe.transform.position.z);
                transform.position = newPos;
                rb.useGravity = false;
                isConnected = true;
            }

        }
        if (isConnected)
        {
            se.Play(AudioManager.Instance.pipeSE);
            wheel.spin = true;
            water.StopFlow();
        }
        if (isFollowing)
        {
            transform.position = player.transform.position + offset;
        }
    }


}
