using UnityEngine;

public sealed class BallJump : MonoBehaviour
{
    private bool hasJumped = false;
    private Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update() => CheckOrJump();

    private void CheckOrJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            hasJumped = true;
            float randomDirection = Random.Range(-1.0f, 1.0f);
            Vector3 forceDir = new Vector3(randomDirection, 1, 0);
            forceDir.Normalize();

            rb?.transform.SetParent(null);
            rb?.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);

            Destroy(this);
        }
    }
}
