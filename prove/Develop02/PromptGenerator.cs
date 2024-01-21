using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Reflect on a scripture and its application to your life today.",
        "What is something you wish future generations know about your life?",
        "What is one thing that has impacted your life recently?",
        "What was the best part of your day?",
        "What small and simple things have brought you joy/peace recently?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        // The range is [0 - _prompts.count]
        int randPrompt = random.Next(_prompts.Count);

        return _prompts[randPrompt];
    }
}