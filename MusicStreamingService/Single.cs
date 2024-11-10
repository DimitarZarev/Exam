using System;
using System.Collections.Generic;
using System.Text;

public class Single : Song
{
    private DateTime releaseDate;

    public DateTime ReleaseDate
    {
        get
        {
            return releaseDate;
        }
        set
        {
            releaseDate = value;
        }
    }

    public Single(string title, int duration, string artist, string genre, DateTime releaseDate)
        : base(title, duration, artist, genre)
    {
        this.ReleaseDate = releaseDate;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Duration: {Duration} seconds");
        sb.AppendLine($"Artist: {Artist}");
        sb.AppendLine($"Release Date: { ReleaseDate}");


        return sb.ToString().Trim();
    }
}


