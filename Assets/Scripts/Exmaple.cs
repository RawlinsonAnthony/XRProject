using UnityEngine;

public class Exmaple : MonoBehaviour
{

    [SerializeField] float forceValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
        //cannonAngle = GetAngle();
        //AddForce(angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForce(Vector3 angle)
    { 
        GetComponent<Rigidbody>().AddForce(angle * forceValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision - {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger - {other.gameObject.name}");
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(other.transform.forward * 1000);
       
    }

}
