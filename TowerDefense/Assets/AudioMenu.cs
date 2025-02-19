using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField] private AudioClip[] _audioClip; 

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Highlight()
    {
        _audioSource.PlayOneShot(_audioClip[UnityEngine.Random.Range(0, 1)]);
    }

    public void Play()
    {
        _audioSource.PlayOneShot(_audioClip[2]);
    }
}
