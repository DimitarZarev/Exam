using System;
using System.Collections.Generic;
using System.Text;

public class AlbumSong : Song
{
    private string albumName;

    public string AlbumName
    {
        get
        {
            return albumName;
        }
        set
        {
            if (value.Length < 3||value.Length>100)
            {
                throw new ArgumentException("Album name should be between 3 and 100 characters!");
            }
            albumName = value;
        }
    }

    public AlbumSong(string title, int duration, string artist, string genre, string albumName)
        : base(title, duration, artist, genre)
    {
        this.AlbumName = albumName;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Duration: {Duration} seconds");
        sb.AppendLine($"Artist: {Artist}");
        sb.AppendLine($"Album: {AlbumName}");


        return sb.ToString().Trim();
    }
}

