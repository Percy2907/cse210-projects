using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        int hidden = 0;
        List<int> visibleIndices = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visibleIndices.Add(i);
        }

        while (hidden < count && visibleIndices.Count > 0)
        {
            int index = rand.Next(visibleIndices.Count);
            _words[visibleIndices[index]].Hide();
            visibleIndices.RemoveAt(index);
            hidden++;
        }
    }

    public void RevealOneHiddenWord()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden())
            {
                _words[i].Reveal();
                break;
            }
        }
    }

    public string GetDisplayText()
    {
        string text = $"{_reference.GetDisplayText()}\n\n";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }
}