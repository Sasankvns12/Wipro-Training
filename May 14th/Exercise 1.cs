using System;
public interface IMusicPlayer
{
    public void Play(string song);
    public void Pause();
    public void Stop();
    
}
class SpotifyPlayer : IMusicPlayer
{
    public void Play(string song)
    {
        Console.WriteLine("Playing[song] on spotify");
    }
    public void Pause()
    {
        Console.WriteLine("Spotify Playback Paused");
    }
    public void Stop()
    {
        Console.WriteLine("Spotify Playback Stopped");
    }
}
class AppleMusicPlayer : IMusicPlayer
{
    public void Play(string song)
    {
        Console.WriteLine("Playing[song] on AppleMusic");
    }
    public void Pause()
    {
        Console.WriteLine("AppleMusic Playback Paused");
    }
    public void Stop()
    {
        Console.WriteLine("AppleMusic Playback Stopped");
    }
}
class Program
{
    public static void Main()
    {
        IMusicPlayer SpotifyPlayer = new SpotifyPlayer();
        IMusicPlayer AppleMusicPlayer = new AppleMusicPlayer();
        Console.WriteLine("Spotify Songs :");
        SpotifyPlayer.Play("Bohemian Rhapsody");
        SpotifyPlayer.Pause();
        SpotifyPlayer.Stop();
        Console.WriteLine("\nAppleMusic Songs :");
        AppleMusicPlayer.Play("Sweet Child O'Mine");
        AppleMusicPlayer.Pause();
        AppleMusicPlayer.Stop();
    }
}
