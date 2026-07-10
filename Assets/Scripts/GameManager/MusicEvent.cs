using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicEvent : MonoBehaviour
{
    [SerializeField] private float markInEventChange;// has to be less than markout
    [SerializeField] private float markOutEventChange;// has to be more than markin
    [SerializeField] private float timeBeforeGameFinished;
    [SerializeField] private GameObject gameFinishedScreen;
    [SerializeField] private AudioSource vfxAudioSource;
    [SerializeField] private AudioClip victorySoundEffect;

    public Action<bool> GameStateChangeEvent;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Timer()
    {
        StartCoroutine(StartInTimer());
    }

    private void TrackMusicTime()
    {
        float remaining = audioSource.clip.length - audioSource.time - timeBeforeGameFinished;
        if(remaining <= 0)
        {
            GameFinished();
        }
    }

    private void GameFinished()
    {
        vfxAudioSource.clip = victorySoundEffect;
        vfxAudioSource.Play();
        Time.timeScale = 0f;
        gameFinishedScreen.SetActive(true);
    }

    private IEnumerator StartInTimer()
    {
        GameStateChangeEvent?.Invoke(false);
        yield return new WaitForSeconds(markInEventChange);
        StartCoroutine(StartOutTimer());
    }

    private IEnumerator StartOutTimer()
    {
        GameStateChangeEvent?.Invoke(true);
        Debug.LogWarning("StartedEventWindow");
        yield return new WaitForSeconds(markOutEventChange);
        GameStateChangeEvent?.Invoke(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.Play();
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMusicTime();
    }
}
