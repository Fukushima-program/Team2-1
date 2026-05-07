using UnityEngine;


public class Conveyor : MonoBehaviour
{

    public float ConveyorSpeed = 3.0f;
    public bool isConveyor = false;

    private void OnTriggerStay(Collider other)
    {
        if (!isConveyor) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(Vector3.right * ConveyorSpeed, ForceMode.VelocityChange);
        }

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.AddExternalForce(Vector3.right * ConveyorSpeed);
        }
    }

    public void StartConveyor()
    {
        isConveyor = true;
    }

    public void StopConveyor()
    {
        isConveyor = false;
    }
}
