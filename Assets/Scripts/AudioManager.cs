using System.Linq;
using UnityEngine;

/// <summary>
/// Manage scene audio
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Manager;

    public Sound[] Sounds;

    private void Awake()
    {
        if (Manager == null)
        {
            Manager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        ///Initial audiomanaged components
        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    public void Play(string soundName)
    {
        Sound sound = Sounds.First(s => s.Name == soundName);
        
        if(sound == null)
        {
            Debug.Log($"Sound: {soundName} not found!");
            return;
        }

        sound.Source.Play();
    }

    public void Stop(string soundName)
    {
        Sound sound = Sounds.First(s => s.Name == soundName);

        if (sound == null)
        {
            Debug.Log($"Sound: {soundName} not found!");
            return;
        }

        sound.Source.Stop();
    }

    public Sound GetSound(string soundName)
    {
        return Sounds.First(s => s.Name == soundName);
    }
}
