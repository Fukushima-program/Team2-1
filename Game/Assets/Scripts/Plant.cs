using UnityEngine;

public class Plant : MonoBehaviour
{

    public bool isCut = false;

    public float destSpeed = 0.6f;
    public float destScale = 0.3f;


    void Update()
    {

        if (isCut)
        {

            transform.localScale -= Vector3.one * destSpeed * destScale;

            if(transform.localScale.x <= destScale )
            {

               Destroy(gameObject);

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       LawnMower mower = other.GetComponentInParent<LawnMower>();

        if (mower != null && mower.CanCut())
        {

            isCut = true;

            mower.BreakMower();
        }
    }
}

