using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    private List<string> dialogueLines = new List<string>();
    private string targetName;

    private Button dialogueButton;
    private Text dialogueText, targetNameText, PlayerText;
    private int dialogueIndex;

	// Use this for initialization
	void Awake () {
        dialogueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        targetNameText = dialoguePanel.transform.Find("Panel_Target_Name").GetComponentInChildren<Text>();
        
        //add a listener to the continue button
        dialogueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        //hide dialogue panel
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}
    //create new dialogue
    public void AddNewDialogue(string[] lines, string NPCName)
    {
        if (lines.Length > 0)
        {
            dialogueIndex = 0;
            //set panel target name
            this.targetName = NPCName;
            //add lines
            dialogueLines = new List<string>(lines.Length);
            dialogueLines.AddRange(lines);
            CreateDialogue();
        }
    }
    //set up the new dialogue panel
    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        targetNameText.text = targetName;
        ChangeDialogueButtonText();
        //display dialog
        dialoguePanel.SetActive(true);
    }
    //iterate over messages in dialogue
    public void ContinueDialogue()
    {   
        dialogueIndex++;
        ChangeDialogueButtonText();
        if (dialogueIndex < dialogueLines.Count)
        {
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
    //change button text depending on dialogueIndex
    public void ChangeDialogueButtonText()
    {
        if (dialogueIndex == dialogueLines.Count - 1)
        {
            dialogueButton.GetComponentInChildren<Text>().text = "Close";
        }
        else
        {
            dialogueButton.GetComponentInChildren<Text>().text = "Continue";
        }
    }
}
