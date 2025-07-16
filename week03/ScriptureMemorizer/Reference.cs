using System;
public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int? verseEnd;

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (verseEnd.HasValue && verseEnd != verseStart)
        {
            return $"{book} {chapter}:{verseStart}-{verseEnd}";
        }
        else
        {
            return $"{book} {chapter}:{verseStart}";
        }
    }
}