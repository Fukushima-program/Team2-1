using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WorldSE : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.spatialBlend = 1f;
        source.minDistance = 3f;
        source.maxDistance = 10f;
    }

    public void Play(AudioClip clip, bool loop = false)
    {
        source.clip = clip;
        source.loop = loop;
        source.pitch = Random.Range(0.95f, 1.05f);
        source.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        source.pitch = Random.Range(0.95f, 1.05f);
        source.PlayOneShot(clip);
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Pause()
    {
        source.Pause();
    }
    
    public void Resume()
    {
        source.UnPause();
    }
}
