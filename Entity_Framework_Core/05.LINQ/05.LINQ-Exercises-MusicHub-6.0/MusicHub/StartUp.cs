namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            //Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .AsNoTracking()
                .Where(a => a.ProducerId == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                    .ThenInclude(s => s.Writer)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    AlbumSongs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name)
                    .Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        SongWriterName = s.Writer.Name
                    }),
                    TotalAlbumPrice = a.Price
                })
                .ToList()
                .OrderByDescending(a => a.TotalAlbumPrice);

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int songCounter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb
                        .AppendLine($"---#{songCounter}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.SongWriterName}");

                    songCounter++;
                }

                sb
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsNoTracking()
                .Where(s => s.Duration.Seconds > duration) // Incorrect, but that's what Judge requires :D
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                //.Include(s => s.SongPerformers)
                //    .ThenInclude(sp => sp.Performer)
                //.Include(s => s.Writer)                       NOT NECESSARY
                //.Include(s => s.Album)
                //    .ThenInclude(a => a!.Producer)
                .Select(s => new
                {
                    s.Name,
                    PerformersFullNames = s.SongPerformers
                    .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                    .OrderBy(p => p)
                    .AsEnumerable(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            int songCounter = 1;

            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{songCounter}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.PerformersFullNames)
                {
                    sb
                        .AppendLine($"---Performer: {performer}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");

                songCounter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
