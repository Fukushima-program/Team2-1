using System.Xml.Serialization;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;

    private float currentSpeed = 0f;
    private float acceleration = 2f;
    private float speed = 2.0f;
    private Transform target;
    private Elek elek;
    private float stopTimer = 0f;
    private bool isMoving = false;
    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = GetComponent<Elek>();  
        se = GetComponent<WorldSE>();
    }

    void FixedUpdate()
    {

        if (stopTimer > 0f)
        {
            stopTimer -= Time.deltaTime;
            return;
        }

        if(elek.isElektric && !isMoving && stopTimer <= 0f)
        {
            ActivateLift();
            elek.PowerOff();
        }

        if (!isMoving) return;

        currentSpeed = Mathf.MoveTowards(currentSpeed, speed, Time.fixedDeltaTime * acceleration);

        transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = target.position;
            currentSpeed = 0;
            isMoving = false;
            stopTimer = 2f;
            se.Stop();
        }

    }

    public void ActivateLift()
    {
        if (Vector3.Distance(transform.position, targetA.position) < 0.1f)
        {
            target = targetB;
        }
        else
        {
            target = targetA;
        }
        isMoving = true;
       se.Play(AudioManager.Instance.liftSE, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
