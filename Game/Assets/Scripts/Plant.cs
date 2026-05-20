using UnityEngine;

public class Plant : MonoBehaviour
{

    public bool isCut = false;

    public float destSpeed = 0.6f;
    public float destScale = 0.3f;

    private LiftLoop lift;

    void Update()
    {

        if (isCut)
        {

            transform.localScale -= Vector3.one * destSpeed * Time.deltaTime;

            if( transform.localScale.x <= destScale )
            {

                if(lift != null)
                {
                    lift.RestartByPlant();
                }

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


        LiftLoop hitLift = other.GetComponentInParent<LiftLoop>();

        if(hitLift != null)
        {

            lift = hitLift;
            lift.StopByPlant();
        }
    }
}