using UnityEngine.Audio;
using UnityEngine;

// Whenever create a custom class and want it to appear in the inspector we have to mark it as serializable
// erase MonoBehaviour so the script doesn't derive from it
[System.Serializable]
public class Sound
{
    // This script is for controling what data to use for each sound

    public string name;

    public AudioClip clip;

    // Use range so it appear as slider in inspector 
    [Range(0f, 1f)]
    public float volume;
    [Range(0.3f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
