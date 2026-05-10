using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    public float frequency; // speed of movement
    public float magnitude; // distance of movement
    public Vector3 direction; // direction of movement
    private Vector3 initialPosition;

    void Start()
    {
        // Save the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Sine function for smooth bobbing movement
        transform.position = initialPosition + direction * Mathf.Sin(Time.time * frequency) * magnitude;
    }

}
