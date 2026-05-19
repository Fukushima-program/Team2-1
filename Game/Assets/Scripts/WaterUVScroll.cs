using UnityEngine;

public class WaterUVScroll : MonoBehaviour
{
    private Vector2 offset;
    private Renderer rend;
    [SerializeField]
    private float speed;
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        offset.y = (offset.y + speed * Time.deltaTime) % 1f;
        rend.material.mainTextureOffset = offset;
    }
}
