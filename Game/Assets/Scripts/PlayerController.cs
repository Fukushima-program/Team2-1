using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float horizontalSpeed;
    private float verticalSpeed;
    private float maxFallSpeed = 20.0f;
    private float gravity = 60.0f;
    private Transform activeFloor;
    private Vector3 activeLocalFloorPoint;
    private Vector3 activeGlobalFloorPoint;
    private int airFrame;
    private SocketTrigger socket;
    public Transform spawnPoint;
    private byte IdlingTimer;
    private Animator animator;
 
    public float Gage = 100.0f;
    
    public float speed = 5f;
    public bool isInBox = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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
        }
        else
        {
            animator.SetBool("Walking", false);
            IdlingTimer++;
            if (IdlingTimer > 120)
            {
                animator.SetTrigger("Idring");
            }
        }

            horizontalSpeed = horizontal * speed;
    }

    private void UpdateMovement()
    {
        Vector3 move = new Vector3(horizontalSpeed, verticalSpeed, 0f);

        if (activeFloor != null)
        {
            Vector3 newGlobalFloorPoint = activeFloor.TransformPoint(activeLocalFloorPoint);
            Vector3 moveDistance = newGlobalFloorPoint - activeGlobalFloorPoint;
            controller.Move(moveDistance);
        }
        airFrame++;
        if(airFrame > 2)
        {
            activeFloor = null;
        }
        controller.Move(move * Time.deltaTime);
        
        if(activeFloor != null)
        {
            activeGlobalFloorPoint = transform.position;
            activeLocalFloorPoint = activeFloor.InverseTransformPoint(transform.position);
        }
    }

    private void UpdateGravity()
    {
        if (controller.isGrounded)
        {
            verticalSpeed = -2f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        verticalSpeed = Mathf.Max(verticalSpeed, -maxFallSpeed);
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
        speed = 5.0f;
    }

    public void AddExternalForce(Vector3 force)
    {
        controller.Move(force * Time.deltaTime);
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
        verticalSpeed = 0f;
        horizontalSpeed = 0f;


        Warp(spawnPoint.position);
    }

    public void Warp(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }
}
