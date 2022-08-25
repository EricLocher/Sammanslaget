using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static Dictionary<string, AudioClip> sounds;
    static List<AudioSource> sources;
    static List<AudioSource> onLoopSources;

    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

        LoadAudioClips();
        CreateAudioSources();
    }

    void LoadAudioClips()
    {
        sounds = new Dictionary<string, AudioClip>();

        foreach (AudioClip clip in Resources.LoadAll<AudioClip>("Audio")) {
            sounds.Add(clip.name, clip);
        }
    }

    void CreateAudioSources()
    {
        sources = new List<AudioSource>();

        for (int i = 0; i < 5; i++) {
            AudioSource audioSource = new GameObject($"AudioSource ({i})").AddComponent<AudioSource>();
            audioSource.transform.parent = transform;

            sources.Add(audioSource);
        }
    }

    static AudioSource CreateTempAudioSource(float lifeTime)
    {
        AudioSource audioSource = new GameObject($"Temporary AudioSource").AddComponent<AudioSource>();
        audioSource.transform.parent = Instance.transform;

        Destroy(audioSource, lifeTime);
        
        return audioSource;
    }

    static AudioSource CreateTempAudioSource()
    {
        AudioSource audioSource = new GameObject($"Temporary AudioSource").AddComponent<AudioSource>();
        audioSource.transform.parent = Instance.transform;

        return audioSource;
    }


    public static void PlayOneShot(string fileName)
    {
        AudioClip sound = sounds[fileName];

        foreach (AudioSource source in sources) {
            if (!source.isPlaying) {
                source.PlayOneShot(sound);
                break;
            }

            CreateTempAudioSource(sound.length).PlayOneShot(sound);
        }
    }

    public static void PlayOnLoop(string fileName)
    {
        AudioClip sound = sounds[fileName];
        AudioSource source = CreateTempAudioSource();

        source.clip = sound;
        source.loop = true;
        source.Play();

        onLoopSources.Add(CreateTempAudioSource());
    }

    public static void StopLoopingSounds()
    {
        foreach (AudioSource source in onLoopSources) {
            source.Stop();
            Destroy(source);
        }
    }
}
