using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private CharacterController controller;
    //private float horizontalSpeed;
    //private float verticalSpeed;
    //private float maxFallSpeed = 20.0f;
    private float gravity = 6.0f;
    private Transform activeFloor;
    private Vector3 activeLocalFloorPoint;
    private Vector3 activeGlobalFloorPoint;
    private int airFrame;
    public Transform spawnPoint;
    private byte IdlingTimer;
    private Animator animator;
    private float stepTimer;
 
    public float Gage = 100.0f;
    
    public float speed = 5f;
    public bool isInBox = false;
    private int stepIndex;
    private WorldSE se;
    private Rigidbody rb;
    public float horizontalVelocity;
    public float verticalVelocity;
    public bool onGround;

    [Header("RayCast to Ground")]
    public Transform groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        se = GetComponent<WorldSE>();
        rb=GetComponent<Rigidbody>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInBox)
        {

            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                ExitBox();
            }
            return;
        }
        UpdateGravity();
        UpdateDirection();
        UpdateMovement();
        rb.linearVelocity = new Vector3(horizontalVelocity, verticalVelocity, 0f);
        horizontalVelocity = 0;
        verticalVelocity = 0;
        onGround = false;
    }

    private void UpdateDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);

        if (direction != Vector3.zero)
        {
            direction.x *= -1;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
        if (horizontal != 0)
        {
            IdlingTimer = 0;
            animator.SetBool("Walking", true);
            
            stepTimer -= Time.deltaTime;
            if(stepTimer <= 0f)
            {

                se.PlayOneShot(AudioManager.Instance.stepSE[stepIndex]);
                stepIndex++;
                if (stepIndex >= AudioManager.Instance.stepSE.Length)
                {
                    stepIndex = 0;
                }
                stepTimer = 0.2f;
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            stepTimer = 0f;
            IdlingTimer++;
            if (IdlingTimer > 120)
            {
                animator.SetTrigger("Idring");
            }
        }

            horizontalVelocity += horizontal * speed;
    }

    private void UpdateMovement()
    {
        //Vector3 move = new Vector3(horizontalSpeed, verticalSpeed, 0f);

        if (activeFloor != null)
        {
            Vector3 newGlobalFloorPoint = activeFloor.TransformPoint(activeLocalFloorPoint);
            Vector3 moveDistance = newGlobalFloorPoint - activeGlobalFloorPoint;
            //controller.Move(moveDistance);
        }
        airFrame++;
        if(airFrame > 2)
        {
            activeFloor = null;
        }
        //controller.Move(move * Time.deltaTime);
        
        if(activeFloor != null)
        {
            activeGlobalFloorPoint = transform.position;
            activeLocalFloorPoint = activeFloor.InverseTransformPoint(transform.position);
        }
    }

    private void UpdateGravity() 
    {
        /*if (controller.isGrounded)
        {
            verticalSpeed = -2f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }*/
        if(!onGround)
            verticalVelocity -= gravity;
        //verticalVelocity = Mathf.Max(verticalVelocity, -maxFallSpeed);
    }

    public void EnterBox(Transform socketTransform)
    {
        isInBox = true;
        Vector3 pos = socketTransform.position;
        transform.position = new Vector3(pos.x, pos.y + 0.2f, pos.z);
        transform.rotation = socketTransform.rotation;
    }

    private void ExitBox()
    {
        isInBox = false;
        //speed = 5.0f;
    }

    public void AddExternalForce(Vector3 force)
    {
        horizontalVelocity = force.x;
        verticalVelocity = force.y;
    }

    public void PlayerGage(float gage)
    {
            Gage -= gage;   
        
            if( Gage > 100)
        {
            Gage = 100;
        }
    }

    public void PlayerCharge(float charge)
    {
        Gage += charge;

        if (Gage > 100)
        {
            Gage = 100;
        }


    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        FloorCheck(hit);
    }

    private void FloorCheck(ControllerColliderHit hit)
    {
        if(hit.normal.y > 0.9f)
        {
            activeFloor = hit.collider.transform;
            airFrame = 0;
        }
    }

    private void Spawn()
    {
        verticalVelocity = 0f;
        horizontalVelocity = 0f;


        Warp(spawnPoint.position);
    }

    public void Warp(Vector3 position)
    {
        //controller.enabled = false;
        transform.position = position;
        //controller.enabled = true;
    }
}
