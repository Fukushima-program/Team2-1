using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private CharacterController controller;
    private float horizontalSpeed;
    private float verticalSpeed;
    private float maxFallSpeed = 20.0f;
    private float gravity = 60.0f;

    public bool isInBox = false;
    Vector3 boxPosition;
    Vector3 pipePosition;
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
        Vector3 move = new Vector3(horizontalSpeed, verticalSpeed, 0);
        controller.Move(move * Time.deltaTime);
    }

    private void UpdateGravity()
    {
        if (controller.isGrounded)
        {
            verticalSpeed = -gravity * Time.deltaTime;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        verticalSpeed = Mathf.Max(verticalSpeed, -maxFallSpeed);
    }

    public void EnterBox(Vector3 pos)
    {
        isInBox = true;
        boxPosition = pos;
        transform.position = boxPosition;
    }

    private void ExitBox()
    {
        isInBox = false;
    }

    public void AddExternalForce(Vector3 force)
    {
        controller.Move(force * Time.deltaTime);
    }

}
