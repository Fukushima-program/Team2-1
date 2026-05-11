using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public string targetTag = "Player";

    private Elek elek;
    public GameObject elekObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = elekObject.GetComponent<Elek>();
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
                }
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
            }
        }
    }
}
