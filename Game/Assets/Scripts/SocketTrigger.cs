using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public string targetTag = "Player";

    private Elek elek;
    public GameObject elekObject;

    public PlayerController currentPlayer;

    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = elekObject.GetComponent<Elek>();
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer == null) return;

        float distance = Vector3.Distance(currentPlayer.transform.position, transform.position);
        if (distance < 0.8f && Input.GetMouseButtonDown(0) && !currentPlayer.isInBox)
        {
            se.Play(AudioManager.Instance.socketSE);
            currentPlayer.PlayerGage(10);
            currentPlayer.UpdateHealth();
            currentPlayer.EnterBox(transform);
            //currentPlayer.speed = 0.0f;

            if (elek != null)
            {
                elek.PowerOn();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            currentPlayer = other.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (currentPlayer != null)
            {
                currentPlayer.isInBox = false;
            }
            elek.isConnected = false;
            currentPlayer = null;
        }
    }
}
