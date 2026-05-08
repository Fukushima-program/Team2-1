using UnityEngine;

public class Charge : MonoBehaviour
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

        PlayerController player = GetComponent<PlayerController>();

        if(player != null)
        {
            Destroy(gameObject);
        }

    }

}
