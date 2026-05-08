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
    private float boxTimer;

    public float speed = 5f;
    public bool canEnterBox = true;
    public bool isInBox = false;
    Vector3 boxPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        boxTimer += Time.deltaTime;
        if (boxTimer > 0.4f) canEnterBox = true;
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
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation * Quaternion.Euler(90, 0, 0);
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

    public void EnterBox(Vector3 pos)
    {
        boxTimer = 0;
        isInBox = true;
        boxPosition = pos;
        transform.position = boxPosition;
    }

    private void ExitBox()
    {
        isInBox = false;
        speed = 5.0f;
                canEnterBox = false;
    }

    public void AddExternalForce(Vector3 force)
    {
        controller.Move(force * Time.deltaTime);
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
}
