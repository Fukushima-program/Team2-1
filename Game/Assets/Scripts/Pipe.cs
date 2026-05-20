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

    public Valve valve;
    public WaterWheel wheel;
    public WaterFlow water;
    public float pipeOffset = 0f;
    public bool isFollowing = false;
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
 
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFollowing && distance < InteractionDis && !isConnected)
            {
                se.PlayOneShot(AudioManager.Instance.pipeSE);
                rb.useGravity = false;
                isFollowing = true;
            }
            else if (isFollowing)
            {
                rb.useGravity = true;
                isFollowing = false;

                float distance1 = Vector3.Distance(transform.position, pipe.transform.position);
                if (distance1 < 3)
                {
                    Vector3 newPos = new Vector3(pipe.transform.position.x + pipeOffset, pipe.transform.position.y, pipe.transform.position.z);
                    transform.position = newPos;
                    rb.useGravity = false;
                    isConnected = true;
                }
            }
        }

        if (isConnected)
        {
            bool canSpin = true;
            if (valve != null)
            {
                canSpin = valve.isOpened;
            }

            if (canSpin)
            {
                se.Play(AudioManager.Instance.pipeSE);
                wheel.spin = true;
                water.StopFlow();
            }
            else
            {
                wheel.spin = false;
            }
        }
        if (isFollowing)
        {
            transform.position = player.transform.position + offset;
        }
    }


}
