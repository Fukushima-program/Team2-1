using NUnit.Framework.Internal.Commands;
using UnityEngine;


public class Conveyor : MonoBehaviour
{

    public float ConveyorSpeed = 3.0f;

    //public bool isConveyor = false;

    private Elek elek;

    public float acceleration = 5.0f;

    private WorldSE se;
    private bool sePlaying = false;
    public float scrollSpeed;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private Elek obj;
    private Vector2 offset;
    private Renderer rend;
    [SerializeField]
    private bool isReversible = false;

    void Start()
    {
        se = GetComponent<WorldSE>();
        rend = GetComponentInChildren<Renderer>();
        if (obj != null) { 
            elek = obj.GetComponent<Elek>();
        }
        else
            elek = GetComponentInChildren<Elek>();
    }

    private void Update()
    {
        float offsetScroll = scrollSpeed * Time.deltaTime;
        if (isReversible)
        {
            if (!elek.isElektric)
                offsetScroll *= -1;
            goto SKIP;
        }
        if (!elek.isElektric) return;
        SKIP:
        offset.x = (offset.x - offsetScroll) % 1f;
        rend.material.mainTextureOffset = offset;
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 Velos = Vector3.right;
        if (isReversible)
        {
            if (!elek.isElektric)
                Velos.x *= -1;
            goto SKIP;
        }
        if (!elek.isElektric) return;
        SKIP:
        if (!sePlaying)
        {
            se.Play(AudioManager.Instance.conveyerSE, true);
            sePlaying = true;
        }

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && !player.isInBox)
        {
            player.AddExternalForce(Velos * playerSpeed);
            return;
        }

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 targetVelocity = Velos * ConveyorSpeed;

            rb.linearVelocity = Vector3.Lerp(
                rb.linearVelocity,
                new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z),
                acceleration * Time.deltaTime
            );
        }

        Vector3 objPos = other.transform.position;
        objPos.x += ConveyorSpeed*Velos.x;
        other.transform.position = objPos;
    }

    private void OnTriggerExit(Collider other)
    {
        se.Stop();
        sePlaying = false;
    }
}
