using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Struct to create a list of all dialogues (strings) and images (sprites)
[Serializable]
public struct Dialogue
{
    public string text;
    public Sprite image;
}

public class DialogueController : MonoBehaviour
{
    public Dialogue[] dialogues;
    public int currentDialogue = 0;

    // TextField of TextMeshPro to show the current dialogue
    public TextMeshProUGUI dialogueText;

    // Image to show the current image
    public Image dialogueImage;

    // Show the first dialogue when the game starts
    void Start()
    {
        nextDialogue();
    }

    // Every time the player presses the spacebar, the next dialogue is shown
    void Update()
    {
        // Check if the player pressed the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextDialogue();
        }
    }

    // Function to update the current dialogue and move the index to the next one
    public void nextDialogue()
    {
        // Check if the current dialogue index is inbounds
        if (currentDialogue < dialogues.Length)
        {
            // Update the current dialogue text and image
            dialogueText.text = dialogues[currentDialogue].text;
            dialogueImage.sprite = dialogues[currentDialogue].image;
            // Update the current dialogue index
            currentDialogue++;
        }
    }
}
