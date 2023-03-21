using UnityEngine;

public class PlayerUpright : MonoBehaviour
{
    // Set this to the up direction you want the player to face
    public Vector3 uprightDirection = Vector3.up;

    // Set the speed at which the rotation happens
    public float rotationSpeed = 5f;

    private void FixedUpdate()
    {
        // Calculate the rotation needed to align the player with the upright direction
        Quaternion uprightRotation = Quaternion.LookRotation(transform.forward, uprightDirection);

        // Use Slerp to smoothly interpolate between the current rotation and the upright rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, uprightRotation, Time.deltaTime * rotationSpeed);
    }
}