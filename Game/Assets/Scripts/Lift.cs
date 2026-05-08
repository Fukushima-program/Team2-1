using System.Xml.Serialization;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float speed = 2.0f;

    private Transform target;
    private bool canMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = targetB; 
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                if (target == targetA)
                {
                    target = targetB;
                }
                else
                {
                    target = targetA;
                }
            }
        }
    }

    public void StartMove()
    {
        canMove = true;
    }

    public void StopMove()
    {
        canMove = false;
    }

    

}
