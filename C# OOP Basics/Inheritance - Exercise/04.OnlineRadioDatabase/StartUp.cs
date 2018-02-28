using System;
using System.Linq;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        int songsCount = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();

        for (int a = 0; a < songsCount; a++)
        {
            string[] songInfo = Console.ReadLine().Split(';');
            if (songInfo.Length != 3)
            {
                throw new InvalidSongException();
            }

            string artistName = songInfo[0];
            string songName = songInfo[1];
            string[] durationInput = songInfo[2].Split(':');

            try
            {
                if (durationInput.All(ms => int.TryParse(ms, out int temp)) == false)
                {
                    throw new InvalidSongLengthException();
                }

                int[] minsSecs = durationInput.Select(int.Parse).ToArray();

                Song song = new Song(songName, artistName, minsSecs);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        int totalSeconds = songs.Sum(s => s.DurationMinsSecs[1]);
        int totalMinutes = songs.Sum(s => s.DurationMinsSecs[0]);
        totalMinutes += totalSeconds / 60;
        totalSeconds %= 60;
        int totalHours = totalMinutes / 60;
        totalMinutes %= 60;

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s");
    }
}