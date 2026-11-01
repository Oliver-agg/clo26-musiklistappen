using Microsoft.Data.Sqlite;

namespace MusikApp;
public class DbHandler
{
    private readonly string _connectionString;

    public DbHandler(string connectionString)
    {
        _connectionString = connectionString;
    }
    public List<Song> GetAllSongs()
    {
        var songs = new List<Song>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT ID, Title, Length_seconds, Album_id
            FROM Songs
            ORDER BY Title;
            """;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var song = new Song
            {
                ID = reader.GetInt32(0),
                Title = reader.GetString(1),
                Length_seconds = reader.GetInt32(2),
                Album_id = reader.GetInt32(3)
            };
            songs.Add(song);
        }
        return songs;
    }
    public Song? GetSongById(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT ID, Title, Length_seconds, Album_id
            FROM Songs
            WHERE ID = @id;
            """;

        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Song
            {
                ID = reader.GetInt32(0),
                Title = reader.GetString(1),
                Length_seconds = reader.GetInt32(2),
                Album_id = reader.GetInt32(3)
            };
        }
        return null;
    }
    public List<Song> SearchSongs(string search)
    {
        var songs = new List<Song>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            SELECT ID, Title, Length_seconds, Album_id
            FROM Songs
            WHERE Title LIKE @search
            ORDER BY Title;
            """;

        command.Parameters.AddWithValue("@search", $"%{search}%");

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            songs.Add(new Song
            {
                ID = reader.GetInt32(0),
                Title = reader.GetString(1),
                Length_seconds = reader.GetInt32(2),
                Album_id = reader.GetInt32(3)
            });
        }
        return songs;
    }

    public List<(string SongTitle, string AlbumName)> GetSongsWithAlbum()
    {
        var songs = new List<(string SongTitle, string AlbumName)>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
        SELECT Songs.Title, Albums.Title
        FROM Songs
        INNER JOIN Albums ON Songs.Album_id = Albums.ID
        ORDER BY Albums.Release_year, Songs.Title;
        """;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            songs.Add((
                reader.GetString(0),
                reader.GetString(1)
            ));
        }

        return songs;
    }
}
