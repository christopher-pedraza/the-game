using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class VocabularyDiscover : MonoBehaviour
{
    // List of words and their translations that this object will provide
    public List<string> wordList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract()
    {
        // Update the values of undiscoveredWords with the translations from "words" in the GlobalContext from the words that are in the wordList
        foreach (string word in wordList)
        {
            if (GlobalContext.words.ContainsKey(word))
            {
                GlobalContext.undiscoveredWords[word] = GlobalContext.words[word];
                // Display the words that have been discovered
                Debug.Log("Discovered: " + word + " - " + GlobalContext.undiscoveredWords[word]);
            }
        }
    }
}