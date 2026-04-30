using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    public float InteractionDis = 5.0f;
    public PlayerController player;

    public Rigidbody rb;
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    public bool isFollowing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.Log("Player not assigned");
            return;
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < InteractionDis && Input.GetMouseButtonDown(0))
        {
            rb.useGravity = false;
            isFollowing = true;
        }
        if (isFollowing)
        {
            transform.position = player.transform.position + offset;
            Debug.Log(offset);
        }
    }


}
