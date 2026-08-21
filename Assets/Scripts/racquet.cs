using System;
using UnityEngine;
using UnityEngine.Rendering;

public class racquet : MonoBehaviour
{
    BoxCollider col;
    Vector3 previousPos;
    Vector3 currentDirection;
    float force;
    public float forceMultiplier;

    int ballLayer = 3;
    Vector3 rayDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<BoxCollider>();
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentDirection = transform.position - previousPos;
        if(currentDirection != Vector3.zero)
        {
            float distance = Vector3.Distance(previousPos, transform.position);
            col.size = new Vector3(1, 1, 1 + (distance * 10));
        }
        else
        {
            col.size = new Vector3(1, 1, 1);
        }

        rayDirection = currentDirection - previousPos;
        float tempForce = Vector3.Distance(previousPos, transform.position);
        if (tempForce <= 0)
        {
            force -= Time.deltaTime;
            if (force < 0)
            {
                force = 0;
            }
        }
        else
        {
            force = Vector3.Distance(previousPos, transform.position);
        }

        previousPos = transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, 20, ballLayer, QueryTriggerInteraction.Collide))
        {
            if(hit.collider.name == "cannonBall")
            {
                Debug.Log($"Hit object: {hit.collider.name}");

                //hit.transform.position = transform.forward;
                //hit.transform.velo = force;
            }

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.name == "cannonBall")
        {
            Debug.Log("collision with racquet detected");
            collision.GetComponent<CannonBall>().Hit(currentDirection * force * forceMultiplier);
        }
    }
}
