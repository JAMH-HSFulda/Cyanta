using UnityEngine.Audio;
using UnityEngine;


//https://www.youtube.com/watch?v=6OT43pvUyfY //6:51 to add sound effect //10:17 to call sound from another script/object

[System.Serializable]
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0,1)]
    public float volume;
    [Range(.1f,3)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
