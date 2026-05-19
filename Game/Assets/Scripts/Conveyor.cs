using UnityEngine;


public class Conveyor : MonoBehaviour
{

    public float ConveyorSpeed = 3.0f;

    //public bool isConveyor = false;

    public Elek elek;

    public float acceleration = 5.0f;

    private WorldSE se;
    private bool sePlaying = false;
    public float scrollSpeed;
    [SerializeField]
    private float playerSpeed;
    private Vector2 offset;
    private Renderer rend;

    void Start()
    {
        se = GetComponent<WorldSE>();
        rend = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        offset.x = (offset.x - scrollSpeed * Time.deltaTime) % 1f;
        rend.material.mainTextureOffset = offset;
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (elek == null) return;
        if (!elek.isElektric) return;*/

        if (!sePlaying)
        {
            se.Play(AudioManager.Instance.conveyerSE, true);
            sePlaying = true;
        }

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 targetVelocity = Vector3.right * ConveyorSpeed;

            rb.linearVelocity = Vector3.Lerp(
                rb.linearVelocity,
                new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z),
                acceleration * Time.deltaTime
            );
        }

        Vector3 objPos = other.transform.position;
        objPos.x += ConveyorSpeed;
        other.transform.position = objPos;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && !player.isInBox)
        {
            player.AddExternalForce(Vector3.right * playerSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        se.Stop();
        sePlaying = false;
    }
}
