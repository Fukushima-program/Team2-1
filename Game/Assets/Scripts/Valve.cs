using UnityEngine;

public class Valve : MonoBehaviour
{
    public GameObject waterManager;
    private PlayerController player;
    private float InteractionDis = 1.5f;
    private float spinSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterManager.SetActive(false);
        player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= InteractionDis && Input.GetMouseButtonDown(0))
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
            Vector3 rot = transform.eulerAngles;
            

        }
    }
}
