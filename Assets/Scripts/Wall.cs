using UnityEngine;

public class Wall : MonoBehaviour
{

    public findangle test;
    public Rigidbody cannonBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cannonBall = other;
        //if(other.gameObject.name == "cannonBall")
        {
            test = other.GetComponent<findangle>();
            test.Shoot();
        }
    }
}
