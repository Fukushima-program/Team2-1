using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;
    public AudioSource seSource;

    public AudioClip gameBGM;
    public AudioClip[] stepSE;
    public AudioClip waterSE;
    public AudioClip mowerSE;
    public AudioClip liftSE;
    public AudioClip leverSE;
    public AudioClip conveyerSE;
    public AudioClip doorSE;
    public AudioClip gateSE;
    public AudioClip rollBridgeSE;
    public AudioClip socketSE;
    public AudioClip pipeSE;
    public AudioClip waterWheelSE;
    public AudioClip goalSE;
    public AudioClip getItemSE;
    public AudioClip healSE;

    public float bgmVolume;

    private bool bgmPlaying = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!bgmPlaying)
        {
            PlayBGM(gameBGM);
        }
    }

    public void PlaySE(AudioClip clip)
    {
        seSource.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
        bgmSource.Play();
        bgmPlaying = true;
    }

    public void StopSE(AudioClip clip)
    {
        seSource.Stop();
    }

}
