using System.Collections;
using UnityEngine;

// This line allows it to work with the New Input System if you have it installed
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class RacquetSwing : MonoBehaviour
{
    [Header("Swing Settings")]
    public Vector3 swingTargetRotation = new Vector3(-60f, 0f, 0f);
    public float forwardSpeed = 15f;
    public float returnSpeed = 5f;

    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool isSwinging = false;

    void Start()
    {
        startRotation = transform.localRotation;
        targetRotation = startRotation * Quaternion.Euler(swingTargetRotation);
    }

    void Update()
    {
        // Check for click using a method that works on BOTH input systems
        if (GetClickInput() && !isSwinging)
        {
            Debug.Log("Click detected! Starting swing coroutine.");
            StartCoroutine(PerformSwing());
        }
    }

    bool GetClickInput()
    {
        // Automatically detects which input system your project is using
#if ENABLE_INPUT_SYSTEM
        if (Mouse.current != null)
        {
            return Mouse.current.leftButton.wasPressedThisFrame;
        }
#endif

        return Input.GetMouseButtonDown(0);
    }

    IEnumerator PerformSwing()
    {
        isSwinging = true;
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime * forwardSpeed;
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, progress);
            yield return null;
        }

        transform.localRotation = targetRotation;
        progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime * returnSpeed;
            transform.localRotation = Quaternion.Slerp(targetRotation, startRotation, progress);
            yield return null;
        }

        transform.localRotation = startRotation;
        isSwinging = false;
    }
}
