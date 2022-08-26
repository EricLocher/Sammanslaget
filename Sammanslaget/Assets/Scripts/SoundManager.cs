using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static bool soundPaused = false;

    static Dictionary<string, AudioClip> sounds;
    static List<AudioSource> sources;

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

    void Update()
    {
        for (int i = 0; i < sources.Count; i++) {
            if(sources[i] == null) { sources.RemoveAt(i); i--; }
        }    
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
        if (!sounds.ContainsKey(fileName) || soundPaused) { return; }

        AudioClip sound = sounds[fileName];

        foreach (AudioSource source in sources) {
            if (!source.isPlaying) {
                source.PlayOneShot(sound);
                break;
            }

            AudioSource tempSource = CreateTempAudioSource(sound.length);
            tempSource.PlayOneShot(sound);
            sources.Add(tempSource);
        }
    }

    public static void PlayRandomOneShot(string[] fileNames)
    {
        PlayOneShot(fileNames[Random.Range(0, fileNames.Length)]);
    }

    public static void PlayOnLoop(string fileName)
    {
        if(!sounds.ContainsKey(fileName) || soundPaused) { return; }

        AudioClip sound = sounds[fileName];
        AudioSource source = CreateTempAudioSource();

        source.clip = sound;
        source.loop = true;
        source.Play();

        sources.Add(source);
    }

    public static void Pause()
    {
        soundPaused = true;

        foreach (AudioSource source in sources) {
            source.Stop();
        }
    }

    public static void UnPause()
    {
        soundPaused = false;
    }

}
