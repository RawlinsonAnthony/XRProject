using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonBall : MonoBehaviour
{
    findangle foundAngle;
    Rigidbody rb;
    [SerializeField] float forceValue;
    bool isHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        foundAngle = FindAnyObjectByType<findangle>();
    }

    public void AddForce(Vector3 angle)
    {
        rb.linearVelocity = Vector3.zero; //Remove velocity
        rb.AddForce(angle * forceValue);
    }

    public void Hit(Vector3 angle)
    {
        if (isHit == false)
        {
            isHit = true;
            rb.linearVelocity = Vector3.zero; //Remove velocity
            rb.AddForce(angle * forceValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Boundary")
        {
            isHit = false;
            foundAngle.Shoot(rb);
        }
    }
}
