using UnityEngine;

public class LiftLoop : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float speed = 2.0f;

    private Transform target;
    private Elek elek;
    private float stopTimer = 0f;
    private bool sePlaying = false;
    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = targetB;
        elek = GetComponent<Elek>();
        se = GetComponent<WorldSE>();
    }

    void FixedUpdate()
    {
        if (elek.isElektric)
        {
            if (stopTimer > 0f)
            {
                stopTimer -= Time.deltaTime;
                return;
            }

            if(!sePlaying)
            {
                se.Play(AudioManager.Instance.liftSE, true);
                sePlaying = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                se.Stop();
                sePlaying = false;
                if (target == targetA)
                {
                    target = targetB;
                    stopTimer = 2f;
                }
                else
                {
                    target = targetA;
                    stopTimer = 2f;
                }
            }
        }
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