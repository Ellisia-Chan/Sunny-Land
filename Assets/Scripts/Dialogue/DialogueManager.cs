using Ink.Runtime;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance { get; private set; }

    [SerializeField] private List<ObjectDialoguePanel> defaultDialoguePanels;
    private Dictionary<string, ObjectDialoguePanel> registerdDialoguePanels;

    private Story currentStory;
    private bool dialogueIsPlaying = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            registerdDialoguePanels = new Dictionary<string, ObjectDialoguePanel>();
        } else {
            Debug.LogWarning("Found more than One Instance of Dialogue Manager in the scene");
            Destroy(gameObject);
        }
    }

    private void Start() {
        GameInputManager.Instance.OnDialogueContinueAction += GameInputManager_OnDialogueContinueAction;
    }

    /// <summary>
    /// Handles the continue action of the player
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameInputManager_OnDialogueContinueAction(object sender, System.EventArgs e) {
        if (dialogueIsPlaying) {
            ContinueStory();
        }
    }

    /// <summary>
    /// Registers a new dialogue panel to create dynamic panels for different characters speaking
    /// </summary>
    /// <param name="speakerID">Speaker tag of the character</param>
    /// <param name="dialoguePanel">Dialogue Panel attached to the character GameObject</param>
    /// <param name="dialogueText">Dialogue Text attached to the dialogue panel</param>
    private void RegisterDialoguePanel(string speakerID, GameObject dialoguePanel, TextMeshProUGUI dialogueText) {
        if (!registerdDialoguePanels.ContainsKey(speakerID)) {
            registerdDialoguePanels[speakerID] = new ObjectDialoguePanel {
                speakerID = speakerID,
                dialoguePanel = dialoguePanel,
                dialogueText = dialogueText
            };
        } else {
            Debug.LogWarning($"There is already a panel registered for {speakerID}, Overwriting...");
            registerdDialoguePanels[speakerID].dialoguePanel = dialoguePanel;
            registerdDialoguePanels[speakerID].dialogueText = dialogueText;
        }
    }

    /// <summary>
    /// Starts the dialogue mode with the given inkJSON
    /// </summary>
    /// <param name="inkJSON">Ink JSON file containing the dialogues</param>
    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;

        foreach (var panel in defaultDialoguePanels) {
            RegisterDialoguePanel(panel.speakerID, panel.dialoguePanel, panel.dialogueText);
        }

        ContinueStory();
    }

    /// <summary>
    ///  Continues the current story line
    /// </summary>
    /// 
    private void ContinueStory() {
        if (currentStory.canContinue) {
            string storyText = currentStory.Continue();
            HandleDialogue(storyText);
        } else {

        }
    }

    private void HandleDialogue(string dialogueText) {

    }
}
