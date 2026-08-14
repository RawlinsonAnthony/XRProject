using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonBall : MonoBehaviour
{
    findangle foundAngle;
    Rigidbody rb;
    [SerializeField] float forceValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        foundAngle = FindAnyObjectByType<findangle>();
    }

    public void AddForce(Vector3 angle)
    {
        //foundAngle.Shoot();
        //rb.useGravity = true;
        rb.linearVelocity = Vector3.zero; //Remove velocity
        GetComponent<Rigidbody>().AddForce(angle * forceValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
        //cannonBall = other;
        //if(other.gameObject.name == "floor")
        { 
            foundAngle.Shoot(rb);
        }
    }
}
