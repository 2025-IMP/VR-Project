using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("BGM Clips")]
    public AudioClip titleBGM;
    public AudioClip inGameBGM;

    [Header("SFX Clips")]
    public AudioClip clickSFX;
    public AudioClip gunShootSFX;
    public AudioClip reloadSFX;
    public AudioClip teleportSFX;
    public AudioClip itemGetSFX;
    public AudioClip monsterDieSFX;

    public float BGMVolume => bgmSource.volume;
    public float SFXVolume => sfxSource.volume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            bgmSource.volume = PlayerPrefs.GetFloat("bgm", 0.3f);
            sfxSource.volume = PlayerPrefs.GetFloat("sfx", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioType type, AudioClip clip)
    {
        if (clip == null) return;

        if (type == AudioType.BGM)
        {
            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
        else if (type == AudioType.SFX)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetVolume(AudioType type, float value)
    {
        switch (type)
        {
            case AudioType.BGM:
                bgmSource.volume = value;
                break;
            case AudioType.SFX:
                sfxSource.volume = value;
                break;
        }
    }
}
