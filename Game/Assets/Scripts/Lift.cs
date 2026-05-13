using System.Xml.Serialization;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float speed = 2.0f;

    private Transform target;
    private Elek elek;
    private float stopTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = GetComponent<Elek>();  
    }

    void FixedUpdate()
    {
        if (!elek.isElektric) return;

        if (stopTimer > 0f)
        {
            stopTimer -= Time.deltaTime;
            return;
        }

        if(target == null)
        {
            if (Vector3.Distance(transform.position, targetA.position) < 0.1f)
            {
                target = targetB;
            }
            else
            {
                target = targetA;
            }
        }

        if (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = target.position;

            target = null;
            stopTimer = 2f;
            elek.PowerOff();
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
    }

    //public void StartMove()
    //{
    //    canMove = true;
    //}

    //public void StopMove()
    //{
    //    canMove = false;
    //}

    
    
}
