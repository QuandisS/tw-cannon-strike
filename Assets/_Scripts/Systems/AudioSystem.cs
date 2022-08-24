using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : StaticInstance<AudioSystem>
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _shotClip;

    private AudioSource _audioSource;
    private bool _isMuted = false;

    public bool IsMuted => _isMuted;

    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        _audioSource.volume = _isMuted? 0f : 1f;
    }
    
    public void PlayMusic()
    {
        _audioSource.Play();
    }

    private void OnValidate()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = _musicClip;
    }

    private void Start() 
    {
        PlayMusic();
    }
}
