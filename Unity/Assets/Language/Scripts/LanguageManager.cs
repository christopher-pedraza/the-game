using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class LanguageManager : MonoBehaviour
{
    // TextMeshPro object to display the text
    TextMeshProUGUI mText;
    // List of the words that will be displayed in the text
    private List<string> wordList;
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        wordList = SeparateWordsAndPlaceholders(text, "${", "}");

        foreach (string extractedString in wordList)
        {
            Debug.Log(extractedString);
        }

        // Get the TextMeshPro object
        mText = GetComponent<TMPro.TextMeshProUGUI>();

        // Fill the dictionary with the words and their translations
        GlobalContext.words.Add("awdw", "hello");
        GlobalContext.words.Add("grt", "friend");
        GlobalContext.words.Add("dd", "welcome");
        GlobalContext.words.Add("tjmi", "to");
        GlobalContext.words.Add("jkoyjkmo", "this");
        GlobalContext.words.Add("dwaihdb", "world");

        // Fill the undiscovered words dictionary with the words and their translations
        GlobalContext.undiscoveredWords.Add("awdw", "awdw");
        GlobalContext.undiscoveredWords.Add("grt", "grt");
        GlobalContext.undiscoveredWords.Add("dd", "dd");
        GlobalContext.undiscoveredWords.Add("tjmi", "tjmi");
        GlobalContext.undiscoveredWords.Add("jkoyjkmo", "jkoyjkmo");
        GlobalContext.undiscoveredWords.Add("dwaihdb", "dwaihdb");

        updateText();
    }

    // Update the text
    public void updateText()
    {
        // Clear the text
        mText.text = "";
        // Iterate over the word list updating the text
        foreach (string word in wordList)
        {
            // If the word is in the undiscovered words dictionary, update it with the translation
            if (GlobalContext.undiscoveredWords.ContainsKey(word))
            {
                mText.text += GlobalContext.undiscoveredWords[word];
            }
            // If the word is not in the undiscovered words dictionary, update it with the original word
            // For example, if the word is a comma or a period
            else
            {
                mText.text += word;
            }
        }
    }

    public static List<string> SeparateWordsAndPlaceholders(string input, string start, string end)
    {
        List<string> separatedStrings = new List<string>();

        // Define the pattern using regular expression
        string pattern = $"{Regex.Escape(start)}(.*?){Regex.Escape(end)}";
        Regex regex = new Regex(pattern);

        // Find all matches in the input string
        MatchCollection matches = regex.Matches(input);

        int currentIndex = 0;

        // Process matches and the text in between
        foreach (Match match in matches)
        {
            if (match.Index > currentIndex)
            {
                // Add the text before the match
                separatedStrings.Add(input.Substring(currentIndex, match.Index - currentIndex));
            }

            // Add the placeholder
            separatedStrings.Add(match.Groups[1].Value);

            currentIndex = match.Index + match.Length;
        }

        // Add the remaining text after the last match
        if (currentIndex < input.Length)
        {
            separatedStrings.Add(input.Substring(currentIndex));
        }

        return separatedStrings;
    }

    /*
    All THIS WILL BE REMOVED AS WE WON'T NEED TO UPDATE THE TEXT MULTIPLE TIMES, JUST EACH TIME IT'S SHOWN, AND THE UPDATE RANDOM WORD WILL BE IMPLEMENTED WITH THE KNOWLEDGE PILLARS
    */
    private void updateRandomWord()
    {
        // Get a random word from the undiscovered words dictionary
        List<string> keyList = new List<string>(GlobalContext.words.Keys);
        string randomWord = keyList[UnityEngine.Random.Range(0, keyList.Count)];


        // Update the translation with the correct translation
        GlobalContext.undiscoveredWords[randomWord] = GlobalContext.words[randomWord];

        // Print the word that was discovered
        Debug.Log("Discovered word: " + randomWord + " = " + GlobalContext.undiscoveredWords[randomWord]);
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
            // updateRandomWord();
            updateText();

        }
    }
}
