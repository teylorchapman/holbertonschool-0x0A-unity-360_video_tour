using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float maxLookUpAngle = 80.0f;
    public float maxLookDownAngle = -80.0f;

    private Vector3 dragOrigin;
    private bool isDragging = false;

    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
        {
            isDragging = false;
            return;
        }

        if (isDragging)
        {
            Vector3 difference = dragOrigin - Input.mousePosition;

            float rotateX = -difference.y * rotationSpeed;
            float rotateY = difference.x * rotationSpeed;

            Vector3 currentRotation = transform.eulerAngles;
            float newRotationX = currentRotation.x + rotateX;
            float newRotationY = currentRotation.y + rotateY;

            newRotationX = Mathf.Clamp(newRotationX, maxLookDownAngle, maxLookUpAngle);

            transform.rotation = Quaternion.Euler(newRotationX, newRotationY, 0);
            dragOrigin = Input.mousePosition;
        }
    }
}