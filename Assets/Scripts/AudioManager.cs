using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Music")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _menuBgmClip;
    [SerializeField] AudioClip _schoolBgmClip;

    [Header("Sound Effect")]
    [SerializeField] AudioClip _uiClickSfxClip;
    [SerializeField] AudioClip _correctAnswerSfxClip;
    [SerializeField] AudioClip _wrongAnswerSfxClip;
    [SerializeField, Range(0, 1f)] float _sfxVolume;

    [Header("Voice Over")]
    [SerializeField, Range(0, 1f)] float _voiceOverVolume;

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

    public void PlayMenuBackgroundMusic()
    {
        PlayBGM(_menuBgmClip);
    }

    public void PlaySchoolBackgroundMusic()
    {
        PlayBGM(_schoolBgmClip);
    }

    public void PlayClickSoundEffect()
    {
        PlayClip(_uiClickSfxClip, _sfxVolume);
    }

    public void PlayCorrectAnswerSoundEffect()
    {
        PlayClip(_correctAnswerSfxClip, _sfxVolume);
    }

    public void PlayWrongAnswerSoundEffect()
    {
        PlayClip(_wrongAnswerSfxClip, _sfxVolume);
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        PlayClip(clip, _voiceOverVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPos, volume);
        }
    }

    void PlayBGM(AudioClip clip)
    {
        if (clip != null)
        {
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.playOnAwake = true;
            _audioSource.Play();
        }
    }
}
