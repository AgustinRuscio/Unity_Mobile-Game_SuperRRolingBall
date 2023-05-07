using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioInstance _audioInstance;

    private List<AudioClip> _clipsList = new List<AudioClip>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void RemoveFromList(AudioClip clip)
    {
        if (_clipsList.Contains(clip))
            _clipsList.Remove(clip);
    }


    /// <summary>
    /// For static objects
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="pos"></param>
    /// <param name="loop"></param>
    /// <param name="sound3D"></param>
    /// <param name="maxDistanace"></param>
    public void AudioPlayWithPos(SoundData audio, Vector3 position)
    {
        if (!_clipsList.Contains(audio.clip))
        {
            var x = Instantiate(_audioInstance, position, transform.rotation);
            x.IntancePlay(audio);
            _clipsList.Add(audio.clip);
        }
    }

    /// <summary>
    /// For objets that move around the map
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="obj"></param>
    /// <param name="loop"></param>
    /// <param name="sound3D"></param>
    /// <param name="maxDistamce"></param>
    public void AudioPlayWithTrans(SoundData audio, Transform obj)
    {
        var a = Instantiate(_audioInstance, obj.position, obj.rotation);
        a.transform.parent = obj;

        a.IntancePlay(audio);
    }

    /// <summary>
    /// For menus
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="loop"></param>
    /// <param name="sound3D"></param>
    /// <param name="maxDistamce"></param>
    public void AudioPlay(SoundData audio)
    {
        var a = Instantiate(_audioInstance);

        a.IntancePlay(audio);
    }
}

[System.Serializable]
public struct SoundData
{
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    public bool loop;
    public bool sound3D;
    public float maxDistance;
}