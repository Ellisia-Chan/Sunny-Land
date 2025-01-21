using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance { get; private set; }

    [SerializeField] private ObjectDialoguePanel playerDialoguePanel = new ObjectDialoguePanel();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public ObjectDialoguePanel GetPlayerDialoguePanel() {
        return playerDialoguePanel;
    }
}
