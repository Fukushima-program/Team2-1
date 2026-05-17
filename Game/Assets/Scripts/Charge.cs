using UnityEngine;

public class Charge : MonoBehaviour
{
    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        se = GetComponent<WorldSE>();
    }


    private void OnTriggerEnter(Collider other)
    {
        se.PlayOneShot(AudioManager.Instance.healSE);
        PlayerController player = other.GetComponent<PlayerController>();


        if(player != null)
        {

            player.PlayerCharge(50);

            Destroy(gameObject);
        }

    }

}
