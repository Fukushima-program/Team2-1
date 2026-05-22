using UnityEngine;

public class Bridge : MonoBehaviour
{
    private float speed = 9.0f;
    [SerializeField]
    private Elek elek;
    private WorldSE se;
    private bool sePlaying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (elek != null)
        {
            elek=elek.GetComponent<Elek>();
        }
        else
            elek = GetComponent<Elek>();
        se = GetComponent<WorldSE>();
    }

    // Update is called once per frame
    void Update()
    {
        if(elek.isElektric)
        {
            if (!sePlaying)
            {
                se.Play(AudioManager.Instance.liftSE, true);
                sePlaying = true;
            }

            
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            Vector3 rot = transform.eulerAngles;

            float zRot = rot.z;
            if (zRot > 180) zRot -= 360;
            zRot = Mathf.Clamp(zRot, 0f, 50f);

            transform.eulerAngles = new Vector3(rot.x, rot.y, zRot);

            if(zRot <= 0f)
            {
                se.Stop();
            }
        }
    }

}
