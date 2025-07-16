using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        string[] splitWords = text.Split(' ');
        foreach (string w in splitWords)
        {
            words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        int hidden = 0;

        while (hidden < count)
        {
            int index = rand.Next(words.Count);
            if (!words[index].IsHidden())
            {
                words[index].Hide();
                hidden++;
            }

            // Break if all words are already hidden
            if (IsCompletelyHidden())
                break;
        }
    }

    public string GetDisplayText()
    {
        string display = reference.GetDisplayText() + " - ";
        foreach (Word word in words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}