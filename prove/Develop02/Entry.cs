using System;
using Newtonsoft.Json;

public class Entry
{
    // Attributes for serialization and deserialization
    // Tell JSON serializer how to map the C# class properties to JSON properties
    [JsonProperty("date")]
    public string _date;

    [JsonProperty("promptText")]
    public string _promptText;

    [JsonProperty("entryText")]
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }
}