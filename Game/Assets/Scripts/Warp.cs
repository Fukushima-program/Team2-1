using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform outPosition;
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
        if (outPosition == null) return;

        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            player.Warp(outPosition.position);
        }
    }
}
