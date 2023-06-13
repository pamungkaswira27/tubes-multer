using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Voice Over")]
    [SerializeField, Range(0, 1f)] float _voiceOverVolume;

    Camera _cam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _cam = Camera.main;
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        PlayClip(clip, _voiceOverVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, _cam.transform.position, volume);
        }

    }
}
