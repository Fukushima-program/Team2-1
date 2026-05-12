using UnityEngine;

public class LiftLoop : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float speed = 2.0f;

    private Transform target;
    private Elek elek;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = targetB;
        elek = GetComponent<Elek>();
    }

    void FixedUpdate()
    {
        if (elek.isElektric)
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



}