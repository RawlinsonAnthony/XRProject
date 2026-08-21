using Unity.VisualScripting;
using UnityEngine;

public class findangle : MonoBehaviour
{
    public Vector3 cannonAngle;
    public Rigidbody cannonBall;
    public Transform cannonTip;
    public float shootForce;

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
        cannonBall.useGravity = true;
        cannonBall.linearVelocity = Vector3.zero; //Remove velocity
        cannonBall.position = cannonTip.position;
        cannonBall.AddForce(cannonAngle * shootForce);
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
        return transform.up;
    }
    public Vector3 ForwardAngle()
    {
        return transform.forward;
    }
}
