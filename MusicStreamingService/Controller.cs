using System;
using System.Collections.Generic;
using System.Text;

public class Controller
{
    private Dictionary<string, User> users;

    public Controller()
    {
        users = new Dictionary<string, User>();
    }

    public string AddUser(List<string> args)
    {
        string username = args[0];
        int age = int.Parse(args[1]);

        User newuser = new User(username, age);
        users.Add(username, newuser);
        return $"Created User {username}!";
    }

    public string AddPlaylist(List<string> args)
    {
        string username = args[0];
        string title = args[1];
        Playlist playlist = new Playlist(title);
        users[username].AddPlaylist(playlist);
        return $"Created Playlist {title} for User {username}!";
    }

    public string AddSongToPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string songTitle = args[2];
        int duration = int.Parse(args[3]);
        string artits = args[4];
        string genre = args[5];
        string type = args[6];

        if (type == "single")
        {
            DateTime releaseDate = DateTime.Parse(args[7]);
            Song playlist = new Single(songTitle, duration, artits, genre, releaseDate);
            Playlist playlistt = new Playlist(playlistTitle);
            users[username].AddPlaylist(playlistt);

            return $"Added song {songTitle} to Playlist {playlistTitle}!";
        }
        if (type == "albumSong")
        {
            string albumName = args[7];
            Song song = new AlbumSong(songTitle, duration, artits, genre, albumName);
            Playlist playlistt = new Playlist(playlistTitle);
            users[username].AddPlaylist(playlistt);
            return $"Added song {songTitle} to Playlist {playlistTitle}!";
        }
        return "";
    }

    public string GetTotalDurationOfPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        Playlist playlist = new Playlist(playlistTitle);
        var totalDuration = playlist.TotalDuration();
        return $"Total duration of {playlistTitle}: {totalDuration} seconds";
    }

    public string GetSongsByArtistFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string artist = args[2];
        var listOfSongs= users[username].GetPlaylistByTitle(playlistTitle).GetSongsByArtist(artist);
        StringBuilder builder = new StringBuilder();
        foreach (var item in listOfSongs)
        {
            builder.AppendLine(item.ToString());
        }
        return builder.ToString().Trim();
        
    }

    public string GetSongsByGenreFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        string genre = args[2];
        var listOfSongs = users[username].GetPlaylistByTitle(playlistTitle).GetSongsByGenre(genre);
        StringBuilder builder = new StringBuilder();
        foreach (var item in listOfSongs)
        {
            builder.AppendLine(item.ToString());
        }
        return builder.ToString().Trim();
    }

    public string GetSongsAboveDurationFromPlaylist(List<string> args)
    {
        string username = args[0];
        string playlistTitle = args[1];
        int duration = int.Parse(args[2]);
        var listOfSongs = users[username].GetPlaylistByTitle(playlistTitle).GetSongsAboveDuration(duration);
        StringBuilder builder = new StringBuilder();
        foreach (var item in listOfSongs)
        {
            builder.AppendLine(item.ToString());
        }
        return builder.ToString().Trim();
    }
}
