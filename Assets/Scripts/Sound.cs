using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Sound descriptor
/// </summary>
[System.Serializable]
public class Sound
{
    public string Name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume = 1f;

    [Range(-3f, 3f)]
    public float Pitch = 1f;

    public bool Loop = false;

    /// <summary>
    /// Visible in Classes but not in Inspector
    /// </summary>
    [HideInInspector]
    public AudioSource Source;
}
