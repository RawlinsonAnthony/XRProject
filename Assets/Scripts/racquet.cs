using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class racquet : MonoBehaviour
{
    BoxCollider col;
    Vector3 previousPos;
    Vector3 currentDirection;
    float force;
    public float forceMultiplier;
    public Rigidbody Racquet;
    public player Player;

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
                //Debug.Log($"Hit object: {hit.collider.name}");

                //hit.transform.position = transform.forward;
                //hit.transform.velo = force;
            }

        }
        Racquet.position = Player.GetPlayerPosition();
        //interact();
    }

    public void interact() //move forward while holding "e"
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 targetVelocity = new Vector3(0f, 2f, 5f);
            Racquet.MovePosition(Racquet.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 targetVelocity = new Vector3(0f, -2f, -5f);
            Racquet.MovePosition(Racquet.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 targetVelocity = new Vector3(-5f, 0f, 0f);
            Racquet.MovePosition(Racquet.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 targetVelocity = new Vector3(5f, 0f, 0f);
            Racquet.MovePosition(Racquet.position + targetVelocity * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.name == "cannonBall")
        {
            //Debug.Log("collision with racquet detected");
            collision.GetComponent<CannonBall>().Hit(currentDirection * force * forceMultiplier);
        }
    }
}
