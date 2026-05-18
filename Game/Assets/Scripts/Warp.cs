using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform outPosition;
    private WorldSE se;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        se = GetComponent<WorldSE>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (outPosition == null) return;

        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            se.Play(AudioManager.Instance.gateSE);
            player.Warp(outPosition.position);
        }
    }
}
