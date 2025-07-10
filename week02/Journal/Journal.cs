using System.Collections.Generic;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) { }

    public void DisplayAll() { }

    public void SaveToFile(string filename) { }

    public void LoadFromFile(string filename) { }
}