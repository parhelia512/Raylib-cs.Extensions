namespace Raylib_cs.Extensions;

public static class AudioStreamEx
{
    /// <summary>
    ///     Checks if an audio stream is ready
    /// </summary>
    public static bool IsReady(this AudioStream stream)
    {
        return Raylib.IsAudioStreamReady(stream);
    }

    /// <summary>
    ///     Unload audio stream and free memory
    /// </summary>
    public static void Unload(this AudioStream stream)
    {
        Raylib.UnloadAudioStream(stream);
    }

    /// <summary>
    ///     Update audio stream buffers with data
    /// </summary>
    public static unsafe void Update<T>(this AudioStream stream, ReadOnlySpan<T> data) where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            Raylib.UpdateAudioStream(stream, ptr, data.Length);
        }
    }

    /// <summary>
    ///     Check if any audio stream buffers requires refill
    /// </summary>
    public static bool IsProcessed(this AudioStream stream)
    {
        return Raylib.IsAudioStreamProcessed(stream);
    }

    /// <summary>
    ///     Check if audio stream is playing
    /// </summary>
    public static bool IsPlaying(this AudioStream stream)
    {
        return Raylib.IsAudioStreamPlaying(stream);
    }

    /// <summary>
    ///     Play audio stream
    /// </summary>
    public static void Play(this AudioStream stream)
    {
        Raylib.PlayAudioStream(stream);
    }

    /// <summary>
    ///     Stop audio stream
    /// </summary>
    public static void Stop(this AudioStream stream)
    {
        Raylib.StopAudioStream(stream);
    }

    /// <summary>
    ///     Pause audio stream
    /// </summary>
    public static void Pause(this AudioStream stream)
    {
        Raylib.PauseAudioStream(stream);
    }

    /// <summary>
    ///     Resume audio stream
    /// </summary>
    public static void Resume(this AudioStream stream)
    {
        Raylib.ResumeAudioStream(stream);
    }

    /// <summary>
    ///     Set volume for audio stream (1.0 is max level)
    /// </summary>
    public static void SetVolume(this AudioStream stream, float volume)
    {
        Raylib.SetAudioStreamVolume(stream, volume);
    }

    /// <summary>
    ///     Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public static void SetPitch(this AudioStream stream, float pitch)
    {
        Raylib.SetAudioStreamPitch(stream, pitch);
    }

    /// <summary>
    ///     Set pan for audio stream (0.5 is centered)
    /// </summary>
    public static void SetPan(this AudioStream stream, float pan)
    {
        Raylib.SetAudioStreamPan(stream, pan);
    }

    // i need to find workarounds to make AudioCallback as separate delegate...

    /// <summary>
    ///     Audio thread callback to request new data
    /// </summary>
    public static unsafe void SetCallback(this AudioStream stream,
        delegate* unmanaged[Cdecl]<void*, uint, void> callback)
    {
        Raylib.SetAudioStreamCallback(stream, callback);
    }

    /// <summary>
    ///     Attach audio stream processor to stream
    /// </summary>
    public static unsafe void AttachProcessor(this AudioStream stream,
        delegate* unmanaged[Cdecl]<void*, uint, void> processor)
    {
        Raylib.AttachAudioStreamProcessor(stream, processor);
    }

    /// <summary>
    ///     Detach audio stream processor from stream
    /// </summary>
    public static unsafe void DetachProcessor(this AudioStream stream,
        delegate* unmanaged[Cdecl]<void*, uint, void> processor)
    {
        Raylib.DetachAudioStreamProcessor(stream, processor);
    }
}