using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerController player;

    private float height = 0.25f;
    private float speed = 2f;
    private Vector3 startPos;
    private WorldSE se;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, startPos.y + y, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            se.Play(AudioManager.Instance.healSE);
            player.PlayerCharge(100);
            Destroy(gameObject);
        }
    }
}
