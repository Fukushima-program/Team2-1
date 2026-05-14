using UnityEngine;


public class Conveyor : MonoBehaviour
{

    public float ConveyorSpeed = 3.0f;

    //public bool isConveyor = false;

    public Elek elek;

    public float acceleration = 5.0f;

    private void OnTriggerStay(Collider other)
    {
        /*if (elek == null) return;
        if (!elek.isElektric) return;*/

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
            float keep = ConveyorSpeed;
            ConveyorSpeed = 3;
            player.AddExternalForce(Vector3.right * ConveyorSpeed);
            ConveyorSpeed = keep;
        }
    }

    //public void StartConveyor()
    //{
    //    isConveyor = true;
    //}

    //public void StopConveyor()
    //{
    //    isConveyor = false;
    //}
}
