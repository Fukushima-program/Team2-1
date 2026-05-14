using UnityEngine;

public class Bridge : MonoBehaviour
{
    private float speed = 3.0f;
    private Elek elek;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elek = GetComponent<Elek>();
    }

    // Update is called once per frame
    void Update()
    {
        if(elek.isElektric)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            Vector3 rot = transform.eulerAngles;

            float zRot = rot.z;
            if (zRot > 180) zRot -= 360;
            zRot = Mathf.Clamp(zRot, 0f, 50f);

            transform.eulerAngles = new Vector3(rot.x, rot.y, zRot);
        }
    }

}
