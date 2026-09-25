using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class camera : MonoBehaviour
{
    public float verticalSpeed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-vertical, 0, 0);
    }
}
