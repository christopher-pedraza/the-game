using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    // Dictionary to store the words and their translations
    public Dictionary<string, string> words = new Dictionary<string, string>();
    // Dictionary of undiscovered words and their current translations
    public Dictionary<string, string> undiscoveredWords = new Dictionary<string, string>();
    // TextMeshPro object to display the text
    public TextMeshProUGUI text;
    // List of the words that will be displayed in the text
    public List<string> wordList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Fill the dictionary with the words and their translations
        words.Add("awdw", "hello");
        words.Add("grt", "friend");
        words.Add("dd", "welcome");
        words.Add("tjmi", "to");
        words.Add("jkoyjkmo", "this");
        words.Add("dwaihdb", "world");

        // Fill the undiscovered words dictionary with the words and their translations
        undiscoveredWords.Add("awdw", "awdw");
        undiscoveredWords.Add("grt", "grt");
        undiscoveredWords.Add("dd", "dd");
        undiscoveredWords.Add("tjmi", "tjmi");
        undiscoveredWords.Add("jkoyjkmo", "jkoyjkmo");
        undiscoveredWords.Add("dwaihdb", "dwaihdb");

        updateText();
    }

    private void updateRandomWord()
    {
        // Get a random word from the undiscovered words dictionary
        List<string> keyList = new List<string>(words.Keys);
        string randomWord = keyList[Random.Range(0, keyList.Count)];


        // Update the translation with the correct translation
        undiscoveredWords[randomWord] = words[randomWord];

        // Print the word that was discovered
        Debug.Log("Discovered word: " + randomWord + " = " + undiscoveredWords[randomWord]);
    }

    // Update the text
    public void updateText()
    {
        // Clear the text
        text.text = "";
        // Iterate over the word list updating the text
        foreach (string word in wordList)
        {
            // If the word is in the undiscovered words dictionary, update it with the translation
            if (undiscoveredWords.ContainsKey(word))
            {
                text.text += undiscoveredWords[word];
            }
            // If the word is not in the undiscovered words dictionary, update it with the original word
            // For example, if the word is a comma or a period
            else
            {
                text.text += word;
            }
        }
    }

    // Update is called once per frame
    async void Update()
    {
        // Check if the player pressed the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set a delay to prevent the player from spamming the spacebar
            // Update the new discovered word and then update the text
            await System.Threading.Tasks.Task.Delay(250);
            updateRandomWord();
            updateText();

        }
    }
}
