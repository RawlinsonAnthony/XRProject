using Unity.VisualScripting;
using UnityEngine;

public class findangle : MonoBehaviour
{
    public Vector3 cannonAngle;
    public Rigidbody cannonBall;
    public Transform cannonTip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cannonBall.position = cannonTip.position;
        cannonAngle = GetAngle();
    }

    // Update is called once per frame
    void Update()
    { 
        cannonBall.position = cannonTip.position;
        cannonBall.AddForce(cannonAngle * 1999);
        if(!cannonBall.IsDestroyed())
        {
            Object.Instantiate(cannonBall);
            Object.Destroy(cannonBall);
        }
        else
        {
            Object.Instantiate("cannonBall(Clone)");
            Object.Destroy(cannonBall);
        }

    }
    public Vector3 GetAngle()
    {
        return transform.up;
    }
}
