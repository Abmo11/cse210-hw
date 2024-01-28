using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Scripture
{
    // ************
    // Member variables
    private Reference _reference;
    private string _fromJsonString; // New variable for holding data from JSON
    private List<Word> _words = new List<Word>();

    // ************
    // Constructor
    public Scripture(string jsonFile)
    {
        LoadFromFile(jsonFile);

        string[] wordsFromText = _fromJsonString.Split(" ");

        foreach (string singleWord in wordsFromText)
        {
            Word newWord = new Word(singleWord);
            _words.Add(newWord);
        }
    }

    // ************
    // Methods
    private void LoadFromFile(string file)
    {
        string jsonString = File.ReadAllText(file);

        // Deserialize JSON into a list of anonymous objects
        var jsonDataList = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);

        // Choose a random index from the list
        Random random = new Random();
        int randomIndex = random.Next(jsonDataList.Count);

        // Get the randomly chosen entry
        var jsonData = jsonDataList[randomIndex];

        // Checks if 'endVerse' key exists in JSON object
        if (jsonData.ContainsKey("endVerse"))
        {
            // 'endVerse' key exists, initialize using the second constructor with endVerse
            _reference = new Reference(
                jsonData["book"].ToString(),
                Convert.ToInt32(jsonData["chapter"]),
                Convert.ToInt32(jsonData["verse"]),
                Convert.ToInt32(jsonData["endVerse"])
            );
        }
        else
        {
            // 'endVerse' key does not exist, initialize using the first constructor
            _reference = new Reference(
                jsonData["book"].ToString(),
                Convert.ToInt32(jsonData["chapter"]),
                Convert.ToInt32(jsonData["verse"])
            );
        }

        // Initialize member variable to a string - from JSON file
        _fromJsonString = jsonData.words.ToString();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Place outside the loop - give generator time to initialize properly
        Random random = new Random();

        for (int i = 1; i <= numberToHide; i++)
        {
            // The range is [0 - _prompts.count]
            int randWord = random.Next(_words.Count);

            _words[randWord].Hide();
        }
    }

    public string GetDisplayText()
    {
        List<string> displayScripture = new List<string>();

        foreach (Word eachWord in _words)
        {
            displayScripture.Add(eachWord.GetDisplayText());
        }

        string displayText = string.Join(" ", displayScripture);

        return $"{_reference.GetDisplayText()} {displayText}";
    }

    public bool IsCompletelyHidden()
    {
        // Checks every Word object in list _words
        foreach (Word word in _words)
        {
            // If the word is displaying
            if (!word.IsHidden())
            {
                return false;
            }
        }
        // Return true if all words are hidden
        return true;
    }
}
