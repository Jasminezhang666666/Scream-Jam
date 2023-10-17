using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image characterPortrait;
    [SerializeField] private GameObject dialoguePanel; // Reference to the UI panel

    private List<string> dialogue = new List<string>();
    private List<string> names = new List<string>();
    private List<Sprite> portraits = new List<Sprite>(); // Add your character portraits here

    [SerializeField] private Player player;

    private int index = 0;

    private void Start()
    {
        AddDialogue("I added a dialogue here", "Player", null);
        AddDialogue("And a dialogue there. We will need to hide the dialogue when no one is talking...?", "NPC", null);
        AddDialogue("SAIHDOIJQWEHOINWDAUIDHSDHJAKSHDJKKAJWHEOQWUEQUEPOQWIEPOQWKPOPXOMSAMKASNKLAKSMXKLMXKNXOAHDIUADPOIWQPOEHIDJAPSMAKSXJPASMXLASKXPJASDIJASPDPNXISAJXPAMXOPASMXPASXIAJDPONWPODNAOWDIPAOMDPAOIDPOAIMDPOAMDIWA", "Player", null);
    }

    private void Update()
    {
        //Press mouse button/Space button to display next text
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (index < dialogue.Count)
            {
                DisplayNextSentence();
            }
            else
            {
                ClearDialogue();
                Debug.Log("End of dialogue.");
                dialoguePanel.SetActive(false);
                player.canMove = true;
            }
        }
    }

    private void DisplayNextSentence()
    {
        dialogueText.text = dialogue[index];
        nameText.text = names[index];
        // Set character portrait here

        index++;
    }

    // Add dialogue to the lists
    private void AddDialogue(string sentence, string characterName, Sprite characterPortrait)
    {
        dialogue.Add(sentence);
        names.Add(characterName);
        portraits.Add(characterPortrait);
    }

    //clear all related dialogue list
    private void ClearDialogue() {
        dialogue.Clear();
        names.Clear();
        portraits.Clear();

        dialogueText.text = null;
        nameText.text = null;
        characterPortrait.sprite = null;
    }

}

