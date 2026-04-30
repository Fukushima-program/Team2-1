using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    
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
        if(other.CompareTag("Player"))
        {

            //Make an event
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.EnterBox(transform.position);
            }
            Debug.Log("Player entered the box");

        }
         
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has left the box");
            

            //Also need an event
        }
    }
}
