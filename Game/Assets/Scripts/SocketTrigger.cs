using UnityEngine;
using UnityEngine.Events;

public class SocketTrigger : MonoBehaviour
{
    public UnityEvent onTrigger;
    public UnityEvent onExit;
    public string targetTag = "Player";

    public Elek elek;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null && player.canEnterBox)
            {
                player.EnterBox(transform.position);
                player.speed = 0.0f;

                if (elek != null)
                {
                    elek.PowerOn();
                    player.PlayerGage(10);
                }

                onTrigger.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.isInBox = false;

                onExit.Invoke();
            }
        }
    }
}
