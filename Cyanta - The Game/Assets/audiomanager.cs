using UnityEngine.Audio;
using System;
using UnityEngine;


//https://www.youtube.com/watch?v=6OT43pvUyfY   //6:51 to add sound effect //10:17 to call sound from another script/object

public class audiomanager : MonoBehaviour
{

    public Sound[] sounds;

    public AudioMixerGroup mixerGroup;

    public static audiomanager instance;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else { //so we dont have multiple instances of audiomanager
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //to use it over mutliple scenes and continue the sound over multiple

        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("BG");
        //Play("Theme"); //for theme music or continous background stuff        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found, check name or file");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Play();
    }
}
