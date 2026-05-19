using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
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
        PlayerController controller = other.GetComponent<PlayerController>();
        if ((controller!=null))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
