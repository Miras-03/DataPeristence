using UnityEngine;

public sealed class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();
    
    private void OnCollisionExit() => CalculateVelocity();

    private void CalculateVelocity()
    {
        var velocity = rb.velocity;

        velocity += velocity.normalized * 0.01f;

        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        if (velocity.magnitude > 3.0f)
            velocity = velocity.normalized * 3.0f;

        rb.velocity = velocity;
    }
}