using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float deadZoneWidth = 2f;
    public float followSpeed = 8f;
    public float yOffset = 2f;

    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        float deltaX = target.position.x - camPos.x;

        if (Mathf.Abs(deltaX) > deadZoneWidth)
        {
            camPos.x = Mathf.Lerp(
                camPos.x,
                target.position.x,
                followSpeed * Time.deltaTime
            );
        }

        camPos.y = target.position.y + yOffset;

        transform.position = new Vector3(
            camPos.x,
            camPos.y,
            transform.position.z
        );
    }
}