using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraHeight, cameraWidth;
    private float playerHalfWidth, playerHalfHeight;

    void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;

        objectPosition.x = Mathf.Clamp(objectPosition.x, -cameraWidth + playerHalfWidth, cameraWidth - playerHalfWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -cameraHeight + playerHalfHeight, cameraHeight - playerHalfHeight);

        transform.position = objectPosition;
    }
}
