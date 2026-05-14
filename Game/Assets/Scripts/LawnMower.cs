using UnityEngine;

public class LawnMower : MonoBehaviour
{
   
  
    public Rigidbody rb;

    public float chargeDistance = 1.0f;

    public float holdDistance = 0.6f;
    public float holdHeight = 0.0f;


    private float height = 0.25f;
    private float speed = 1.5f;
    
    private bool isFollowing = false;
    private bool isCharged = true;
    private bool isBroken = false;
    
    private Vector3 StartPos;
    private Quaternion defaultRotation;  
    public PlayerController player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartPos = transform.position;
        defaultRotation = transform.rotation;
    }

    void Update()
    {
      
        if (isBroken) return;

        if (!isFollowing)
        {
            float y = Mathf.Sin(Time.time * speed) * height;

            transform.position = new Vector3(StartPos.x, StartPos.y + y, StartPos.z);

        }

        else
        {

            FollowPlayer();

            if (Input.GetMouseButtonDown(1))
            {
                UseMower();
            }

        }  
        
    }


    private void OnTriggerEnter(Collider other)
    {

        PlayerController hitplayer = other.GetComponent<PlayerController>();



        if (hitplayer == null) return;

        player = hitplayer;

        PickUp();
        
    }


    private void PickUp()
    {
        isFollowing = true;

        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void FollowPlayer()
    {
        float dir = player.transform.forward.x >= 0 ? 1f : -1f;

        transform.position =
            player.transform.position +
            new Vector3(dir * holdDistance, holdHeight, 0f);

        transform.rotation = defaultRotation;

        if (dir < 0)
        {
            transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void UseMower()
    {
        if (!isCharged)
        {
           return;
        }
    }

    public void ChargeMower()
    {
        if (isBroken) return;
        if (isCharged) return;

        isCharged = true;
    }

    public bool CanCut()
    {
        return isFollowing && isCharged && !isBroken;
    }

    public void BreakMower()
    {
        isBroken = true;
        isFollowing = false;

        Destroy(gameObject);
    }
}