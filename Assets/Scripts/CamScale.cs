using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CamScale : MonoBehaviour
{
    public Transform corner1;
    public Transform corner2;
    public Transform corner3;
    public Transform corner4;
    public Camera mainCamera;

    void Start()
    {
        FitCameraToCorners();
    }


    void FitCameraToCorners()
    {
        Vector3[] corners = new Vector3[] { corner1.position, corner2.position, corner3.position, corner4.position };

        // Compute the bounds (min/max points)
        Bounds bounds = new Bounds(corners[0], Vector3.zero);
        foreach (var corner in corners)
        {
            bounds.Encapsulate(corner);
        }

        // Set camera position to the center
        Vector3 center = bounds.center;
        mainCamera.transform.position = new Vector3(center.x, center.y, mainCamera.transform.position.z);

        // Compute necessary orthographic size
        float width = bounds.size.x;
        float height = bounds.size.y;

        // Adjust for camera aspect ratio
        float cameraSize = Mathf.Max(height / 2f, (width / mainCamera.aspect) / 2f);
        mainCamera.orthographicSize = cameraSize;
    }

}
