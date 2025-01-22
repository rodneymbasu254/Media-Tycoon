using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource[] soundEffectsAudioSources;
    public Slider musicSlider;
    public Slider soundSlider;

    public static AudioSettings instance;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundVolumeKey = "SoundVolume";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float savedSoundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 1f);

        musicSlider.value = savedMusicVolume;
        soundSlider.value = savedSoundVolume;

        musicAudioSource.volume = savedMusicVolume;
        foreach (var soundSource in soundEffectsAudioSources)
        {
            soundSource.volume = savedSoundVolume;
        }

        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        soundSlider.onValueChanged.AddListener(UpdateSoundVolume);
    }

    void UpdateMusicVolume(float value)
    {
        musicAudioSource.volume = value;

        PlayerPrefs.SetFloat(MusicVolumeKey, value);
        PlayerPrefs.Save();
    }

    void UpdateSoundVolume(float value)
    {
        foreach (var soundSource in soundEffectsAudioSources)
        {
            soundSource.volume = value;
        }

        PlayerPrefs.SetFloat(SoundVolumeKey, value);
        PlayerPrefs.Save();
    }
}
