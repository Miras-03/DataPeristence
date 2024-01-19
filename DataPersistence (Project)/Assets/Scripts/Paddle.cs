using UnityEngine;

public sealed class Paddle : MonoBehaviour
{
    [SerializeField] private MainManager mainManager;

    private Vector3 pos;
    private const float speed = 2f;
    private const float maxMovement = 2f;

    private bool hasGameOver = false;

    private void OnEnable() => mainManager.OnGameOver += () => SetFlag(true);

    private void OnDestroy() => mainManager.OnGameOver -= () => SetFlag(false);

    private void FixedUpdate() => CheckOrMove();

    private void CheckOrMove()
    {
        if (!hasGameOver)
        {
            pos = transform.position;
            pos.x += HorizontalInput() * speed * Time.deltaTime;

            CheckOrProtect();

            transform.position = pos;
        }
    }

    private float HorizontalInput() => Input.GetAxis("Horizontal");

    private void CheckOrProtect()
    {
        if (pos.x > maxMovement)
            pos.x = maxMovement;
        else if (pos.x < -maxMovement)
            pos.x = -maxMovement;
    }

    private void SetFlag(bool flag) => hasGameOver = flag;
}