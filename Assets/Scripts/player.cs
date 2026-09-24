using System;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody Player;
    public Vector3 NewPosition;
    Vector3 targetVelocity;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0);
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetVelocity = new Vector3(0f, 0f, 0.5f);
            Player.MovePosition(Player.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetVelocity = new Vector3(0f, 0f, -0.5f);
            Player.MovePosition(Player.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetVelocity = new Vector3(-0.5f, 0f, 0f);
            Player.MovePosition(Player.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetVelocity = new Vector3(0.5f, 0f, 0f);
            Player.MovePosition(Player.position + targetVelocity * Time.fixedDeltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attempting to swing");
            Swing();
        }
    }

    public Vector3 GetPlayerPosition()
    {
        NewPosition = new Vector3(Player.position.x, Player.position.y, Player.position.z + 3);
        return NewPosition;
    }

    public void Swing()
    {

    }

}
