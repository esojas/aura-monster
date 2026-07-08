using System;
using System.Collections;
using UnityEngine;

public class MusicEvent : MonoBehaviour
{
    [SerializeField] private float markInEventChange;// has to be less than markout
    [SerializeField] private float markOutEventChange;// has to be more than markin
    public Action<bool> GameStateChangeEvent;
    private bool startInTimerFinished = false;
    private bool startOutTimerFinished = false;

    private void Timer()
    {

        StartCoroutine(StartInTimer());
    }

    private IEnumerator StartInTimer()
    {
        GameStateChangeEvent?.Invoke(false);
        yield return new WaitForSeconds(markInEventChange);
        startInTimerFinished = true;
        StartCoroutine(StartOutTimer());
    }

    private IEnumerator StartOutTimer()
    {
        GameStateChangeEvent?.Invoke(true);
        Debug.LogWarning("StartedEventWindow");
        yield return new WaitForSeconds(markOutEventChange);
        startOutTimerFinished = true;
        GameStateChangeEvent?.Invoke(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
