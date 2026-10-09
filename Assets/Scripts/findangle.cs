using Unity.VisualScripting;
using UnityEngine;

public class findangle : MonoBehaviour
{
    public Vector3 cannonAngle;
    public Rigidbody cannonBall;
    public Transform cannonTip;
    public float shootForce;
    public GameObject barrel;
    public float randomForceMult;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cannonBall.position = cannonTip.position;
        cannonAngle = GetAngle();
        Shoot(cannonBall);
    }

    // Update is called once per frame
    void Update()
    { 

        
    }


    [ContextMenu("Shoot")]
    public void Shoot(Rigidbody ball)
    {
        randomForceMult = Random.Range(1f, 3f);
        cannonBall.useGravity = true;
        cannonBall.linearVelocity = Vector3.zero; //Remove velocity
        cannonBall.position = cannonTip.position;
        cannonBall.AddForce((randomForceMult * cannonAngle) * shootForce);
    }

    void Example()
    {
        cannonBall.gameObject.SetActive(false); //Turn off
        cannonBall.linearVelocity = Vector3.zero; //Remove velocity
        cannonBall.position = Vector3.zero; //Set position
        cannonBall.gameObject.SetActive(true); //Turn on
    }
    public Vector3 GetAngle()
    {
        return barrel.transform.forward;
    }
}
