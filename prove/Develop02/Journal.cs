using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
// Installed Newtonsoft.Json through command line using otnet add package Newtonsoft.Json
// Need to make sure you're in the correct directory where your C# project is located
// File with .csproj extension should be created in project directory

public class Journal
{
    // Creates list of Entry objects 
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry i in _entries)
        {
            i.Display();
        }
    }
    public void SaveToFile(string file)
    {
        // Serializes list of Entry objects with Newtonsoft.Json
        string jsonString = JsonConvert.SerializeObject(_entries, Formatting.Indented);
        // Writes to file 
        File.WriteAllText(file, jsonString);

        // Code for basic project
        /*using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry i in _entries)
            {
                outputFile.WriteLine(i._date + " -- " + i._promptText + " -- " + i._entryText);
            }
        }*/
    }
    public void LoadFromFile(string file)
    {
        // Reads file 
        string jsonString = File.ReadAllText(file);
        // Deserializes list of Entry objects with Newtonsoft.Json
        _entries = JsonConvert.DeserializeObject<List<Entry>>(jsonString);

        // Code for basic project
        /*string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split(" -- ");
            string date = parts[0];
            string promptText = parts[1];
            string entryText = parts[2];
            Entry newEntry = new Entry();
            newEntry._date = date;
            newEntry._promptText = promptText;
            newEntry._entryText = entryText;
            _entries.Add(newEntry);
        }*/
    }
}