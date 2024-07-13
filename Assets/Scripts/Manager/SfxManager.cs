using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxManager : MonoBehaviour
{
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
    }

    private void Start()
    {
        GameManager.Instance.OnStateChange += PlaySound;
    }

    private void PlaySound(GameState gameState)
    {
        BackgroundAudio backgroundAudioClip = _bgAudioClipList.Find(bgAudioClip => bgAudioClip.GameState == gameState);
        if (backgroundAudioClip == null) return;
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
