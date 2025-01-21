using System;
using UnityEngine;

public class GameInputManager : MonoBehaviour {

    public static GameInputManager Instance { get; private set; }

    public event EventHandler OnDialogueContinueAction;
    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(Instance);
        }

        playerInputActions = new PlayerInputActions();
    }


    private void OnEnable() {
        playerInputActions.Enable();

        playerInputActions.Player.Dialogue_Continue.performed += (context) => OnDialogueContinueAction?.Invoke(this, EventArgs.Empty);
        playerInputActions.Player.Interaction.performed += (context) => OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy() {
        playerInputActions.Disable();
    }

    /// <summary>
    /// Returns the normalized movement vector of the player input 
    /// </summary>
    /// <returns></returns>
    public Vector2 GetPlayerMovementNormalized() {
        return playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }
}
