using UnityEngine;

public class Player2Position : MonoBehaviour
{
    public Transform object1; // Reference to Object 1
    public Transform object2; // Reference to Object 2
    [SerializeField]
    private float xOffset = 8.0f; // Offset on the X-axis

    void Update()
    {
        if (object1 != null && object2 != null)
        {
            // Calculate the new position with offset
            float newXPosition = object2.position.x + (object1.position.x < object2.position.x ? -Mathf.Abs(xOffset) : Mathf.Abs(xOffset));
            object1.position = new Vector3(newXPosition, object2.position.y, object2.position.z);
        }
    }
}
