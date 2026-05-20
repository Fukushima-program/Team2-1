using UnityEngine;

public class Valve : MonoBehaviour
{
    public GameObject waterManager;
    private PlayerController player;
    private float InteractionDis = 1.5f;
    private float spinSpeed = 5f;
    private float rotateAmount;
    private bool isTurning = false;
    private float currentRotate = 0f;
    public bool isOpened = false;
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

        if (distance <= InteractionDis && Input.GetMouseButtonDown(0))
        {
            isTurning = true;
        }

        if (isTurning && currentRotate < 720f)
        {
            rotateAmount += spinSpeed * Time.deltaTime;
            rotateAmount = Mathf.Min(rotateAmount, 720f - currentRotate);
            transform.Rotate(Vector3.forward * rotateAmount);
            currentRotate += rotateAmount;
        }

        if(currentRotate >= 720f)
        {
            isTurning = false;
            isOpened = true;
            waterManager.SetActive(true);
        }

    }
}
