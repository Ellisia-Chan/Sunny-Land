using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("InkJSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Dialogue Option")]
    [SerializeField] private bool playerOnly = false;
    [SerializeField] private bool NPCOnly = false;
    [SerializeField] private bool playerAndNPC = false;

    private bool playerInRange;

    /// <summary>
    /// Handles the validation of the dialogue option to ensure only one option is true
    /// </summary>
    private void OnValidate() {
        ValidateDialogueOption();
    }

    private void Awake() {
        playerInRange = false;
    }

    private void Start() {
        GameInputManager.Instance.OnInteractAction += GameInputManager_OnInteractAction; ;
    }

    private void OnDestroy() {
        GameInputManager.Instance.OnInteractAction -= GameInputManager_OnInteractAction;
    }

    /// <summary>
    /// Handles when the player presses the interaction button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameInputManager_OnInteractAction(object sender, System.EventArgs e) {
        if (playerInRange) {
            Debug.Log("Interacting");
        }
    }

    /// <summary>
    /// Handles when the player enters the trigger and enables the visual cue
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null) {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    /// <summary>
    /// Handles when the player exits the trigger and disables the visual cue
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null) {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }

    /// <summary>
    /// Handles the validation of the dialogue option to ensure only one option is true
    /// </summary>
    private void ValidateDialogueOption() {
        if (playerOnly) {
            NPCOnly = false;
            playerAndNPC = false;
        } else if (NPCOnly) {
            playerOnly = false;
            playerAndNPC = false;
        } else if (playerAndNPC) {
            playerOnly = false;
            NPCOnly = false;
        }
    }
}
