using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        HandlePlayerInput();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandlePlayerInput() {
        moveDir = GameInputManager.Instance.GetPlayerMovementNormalized();
    }

    private void HandleMovement() {
        if (moveDir != Vector2.zero) {
            rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime));
        }
    }

    public Vector2 GetMoveDir() {
        return moveDir;
    }
}
