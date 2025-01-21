using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private const string IS_MOVING = "IsMoving";
    private const string X_MOVEDIR = "X_MoveDir";
    private const string Y_MOVEDIR = "Y_MoveDir";

    private PlayerMovement playerMovement;
    private Animator animator;
    private Vector2 moveDir;
    private Vector2 lastMoveDir;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (playerMovement != null) {
            moveDir = playerMovement.GetMoveDir();

            if (moveDir != Vector2.zero) {
                lastMoveDir = moveDir;
            }

            animator.SetFloat(X_MOVEDIR, lastMoveDir.x);
            animator.SetFloat(Y_MOVEDIR, lastMoveDir.y);
            animator.SetBool(IS_MOVING, moveDir != Vector2.zero);
        }
    }
}
