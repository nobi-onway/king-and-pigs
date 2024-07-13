using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxManager : MonoBehaviour
{
    private bool _isOpenSound;
    public bool IsOpenSound
    {
        get => _isOpenSound;
        set
        {
            _isOpenSound = value;

            if (_isOpenSound)
            {
                if (_audioSource.clip == null) return;
                _audioSource.Play();
            }
            if (!_isOpenSound) _audioSource.Pause();
        }
    }

    [SerializeField]
    private List<BackgroundAudio> _bgAudioClipList;
    private AudioSource _audioSource;
    public static SfxManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        IsOpenSound = true;
    }

    private void Start()
    {
        GameManager.Instance.OnStateChange += PlaySound;
    }

    private void PlaySound(GameState gameState)
    {
        if (!IsOpenSound) return;

        BackgroundAudio backgroundAudioClip = _bgAudioClipList.Find(bgAudioClip => bgAudioClip.GameState == gameState);
        if (backgroundAudioClip == null)
        {
            _audioSource.Stop();
            _audioSource.clip = null;
            return;
        }
        _audioSource.clip = backgroundAudioClip.AudioClip;
        _audioSource.Play();
    }
}

[Serializable]
public class BackgroundAudio
{
    public GameState GameState;
    public AudioClip AudioClip;
}
