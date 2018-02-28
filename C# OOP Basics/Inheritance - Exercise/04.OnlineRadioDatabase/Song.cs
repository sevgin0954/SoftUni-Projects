public class Song
{
    string name;
    string artistName;
    int[] durationMinsSecs;

    public Song(string name, string artistName, int[] durationMinsSecs)
    {
        ArtistName = artistName;
        Name = name;
        DurationMinsSecs = durationMinsSecs;
    }

    public string Name
    {
        get => name;
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            name = value;
        }
    }

    public string ArtistName
    {
        get => artistName;
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            artistName = value;
        }
    }

    public int[] DurationMinsSecs
    {
        get => durationMinsSecs;
        set
        {
            int mins = value[0];
            int secs = value[1];

            if (mins < 0 || mins > 14)
            {
                throw new InvalidSongMinutesException();
            }
            if (secs < 0 || secs > 59)
            {
                throw new InvalidSongSecondsException();
            }

            durationMinsSecs = value;
        }
    }
}