using System;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody Player;
    public Vector3 NewPosition;
    Vector3 targetVelocity;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    float speed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        transform.Translate(speed * movement.normalized * Time.deltaTime);

        float horizontal = horizontalSpeed * Input.GetAxis("Mouse X");
        float vertical = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, horizontal, 0);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attempting to swing");
            Swing();
        }
    }

    public Vector3 GetPlayerPosition()
    {
        NewPosition = new Vector3(Player.position.x, Player.position.y, Player.position.z + 1);
        return NewPosition;
    }

    public void Swing()
    {

    }

}
