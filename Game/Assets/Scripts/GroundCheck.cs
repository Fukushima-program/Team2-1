using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        /*if (player.onGround == true)
            return;*/
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            player.onGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            player.onGround = false;
    }
}
