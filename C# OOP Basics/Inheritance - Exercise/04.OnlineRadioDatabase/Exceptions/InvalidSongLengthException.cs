using System;

public class InvalidSongLengthException : Exception
{
    public override string Message => "Invalid song length.";
}
