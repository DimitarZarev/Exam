using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private string title;

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            if (value.Length < 3 || value.Length>50)
            {
                throw new ArgumentException("Playlist title should be between 3 and 50 characters!");
            }
            title = value;
        }
    }

    private List<Song> songs;

    public Playlist(string title)
    {
        this.songs = new List<Song>();
        this.Title = title;
    }

    public void AddSong(Song song)
    {
        songs.Add(song);        
    }

    public int TotalDuration()
    {
        return songs.Sum(x => x.Duration);     
    }

    public List<Song> GetSongsByArtist(string artist)
    {
        List<Song> songsbyArtist =songs.Where(x => x.Artist == artist).ToList();
        return songsbyArtist.OrderBy(x=>x.Title).ToList();
    }

    public List<Song> GetSongsByGenre(string genre)
    {
        List<Song> songsbyGenre = songs.Where(x => x.Genre == genre).ToList();
        return songsbyGenre.OrderBy(x=>x.Title).ToList();
    }

    public List<Song> GetSongsAboveDuration(int duration)
    {
        List<Song> songsDuration = songs.Where(x => x.Duration >= duration).ToList();
        return  songsDuration.OrderByDescending(x=>x.Duration).ToList();
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Playlist: {Title}");
        sb.AppendLine($"Total Songs: {songs.Count}");

        return sb.ToString().Trim();
    }
}
