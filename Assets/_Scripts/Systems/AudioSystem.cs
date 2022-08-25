using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _shotClip;

    private AudioSource _audioSource;
    private bool _isMuted = false;

    public bool IsMuted => _isMuted;

    public void ToggleMute()
    {
        _isMuted = !_isMuted;
        _audioSource.mute = _isMuted;
    }
    
    public void PlayMusic()
    {
        _audioSource.Play();
    }

    protected override void Awake()
    {
        base.Awake();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = _musicClip;
    }

    private void Start() 
    {
        PlayMusic();   
    }
}
