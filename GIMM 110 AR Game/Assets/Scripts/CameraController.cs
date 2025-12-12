using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The player or target to follow
    public float lockX = 0f; // The x-value to lock the camera to
    public float lockY = 0f; // The y-value to lock the camera to
    public bool lockXAxis = true; // Lock the x-axis
    public bool lockYAxis = true; // Lock the y-axis
    public float smoothTime = 0.3f; // Smoothing time for followin

    private Vector3 velocity = Vector3.zero;
    

    void LateUpdate()
    {

        Vector3 targetPosition = transform.position;

        // Update the camera's position
        if (!lockXAxis)
        {
            targetPosition.x = Mathf.Lerp(transform.position.x, target.position.x, 1f);
        }
        else
        {
            targetPosition.x = lockX;
        }

        if (!lockYAxis)
        {
            targetPosition.y = Mathf.Lerp(transform.position.y, target.position.y, 1f);
        }
        else
        {
            targetPosition.y = lockY;
        }

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    
}