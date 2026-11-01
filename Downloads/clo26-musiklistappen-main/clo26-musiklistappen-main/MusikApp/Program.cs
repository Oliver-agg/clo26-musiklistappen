using Microsoft.Extensions.Configuration;
using MusikApp;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Hittar ingen connection string 'Default' i appsettings.json.");

var db = new DbHandler(connectionString);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== MUSIKLISTAPPEN ===");
    Console.WriteLine("1. Visa alla låtar");
    Console.WriteLine("2. Sök låt via ID");
    Console.WriteLine("3. Sök låtar via titel");
    Console.WriteLine("4. Visa låtar med album (JOIN)");
    Console.WriteLine("0. Avsluta");
    Console.Write("Välj ett alternativ: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                var songs = db.GetAllSongs();

                foreach (var song in songs)
                {
                    Console.WriteLine(
                        $"ID: {song.ID} | {song.Title} | " +
                        $"{FormatDuration(song.Length_seconds)} | " +
                        $"Album-ID: {song.Album_id}");
                }

                break;
            }

        case "2":
            {
                Console.Write("Ange låtens ID: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    var song = db.GetSongById(id);

                    if (song != null)
                    {
                        Console.WriteLine(
                            $"ID: {song.ID} | {song.Title} | " +
                            $"{FormatDuration(song.Length_seconds)} | " +
                            $"Album-ID: {song.Album_id}");
                    }
                    else
                    {
                        Console.WriteLine("Ingen låt hittades med det ID:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ange ett giltigt heltal.");
                }

                break;
            }

        case "3":
            {
                Console.Write("Skriv en del av låttiteln: ");
                string search = Console.ReadLine() ?? "";

                var songs = db.SearchSongs(search);

                if (songs.Count == 0)
                {
                    Console.WriteLine("Inga låtar hittades.");
                }
                else
                {
                    foreach (var song in songs)
                    {
                        Console.WriteLine(
                            $"ID: {song.ID} | {song.Title} | " +
                            $"{FormatDuration(song.Length_seconds)}");
                    }
                }

                break;
            }

        case "4":
            {
                var songs = db.GetSongsWithAlbum();

                foreach (var song in songs)
                {
                    Console.WriteLine(
                        $"{song.SongTitle} — {song.AlbumName}");
                }

                break;
            }

        case "0":
            {
                running = false;
                Console.WriteLine("Programmet avslutas. Hej då!");
                break;
            }

        default:
            {
                Console.WriteLine("Ogiltigt val. Försök igen.");
                break;
            }
    }
}

static string FormatDuration(int seconds)
{
    int minutes = seconds / 60;
    int remainingSeconds = seconds % 60;

    return $"{minutes}:{remainingSeconds:D2}";
}
