using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform sideCamView;
    [SerializeField] private float cameraSmooth = 2f;
    [SerializeField] private MusicEvent musicEvent;
    [SerializeField] private CanvasGroup fadeOverlay;
    [SerializeField] private float fadeDuration = 0.3f;
    [SerializeField] private float blackScreenDuration = 0.5f;

    [Header("Beat Shake")]
    [SerializeField] private float bpm = 113f;
    [SerializeField] private float shakeMagnitude = 0.15f;
    [SerializeField] private float shakePulseDuration = 0.15f;

    private bool GameStateChange = false;
    private Coroutine fadeRoutine;
    private Coroutine beatShakeRoutine;

    private Vector3 basePosition;
    private Vector3 shakeOffset = Vector3.zero;

    private void OnEnable()
    {
        musicEvent.GameStateChangeEvent += HandleGameState;
    }

    private void OnDisable()
    {
        musicEvent.GameStateChangeEvent -= HandleGameState;
    }

    private void HandleGameState(bool state)
    {
        GameStateChange = state;

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeTransition());

        if (state)
        {
            if (beatShakeRoutine == null)
                beatShakeRoutine = StartCoroutine(BeatShakeLoop());
        }
        else
        {
            if (beatShakeRoutine != null)
            {
                StopCoroutine(beatShakeRoutine);
                beatShakeRoutine = null;
            }
            shakeOffset = Vector3.zero;
        }
    }

    private IEnumerator BeatShakeLoop()
    {
        float beatInterval = 60f / bpm;

        while (true)
        {
            yield return StartCoroutine(ShakePulse());
            yield return new WaitForSeconds(beatInterval - shakePulseDuration);
        }
    }

    private IEnumerator ShakePulse()
    {
        float elapsed = 0f;

        while (elapsed < shakePulseDuration)
        {
            elapsed += Time.deltaTime;
            float damper = 1f - (elapsed / shakePulseDuration); // fades out toward end of pulse
            shakeOffset = UnityEngine.Random.insideUnitSphere * shakeMagnitude * damper;
            yield return null;
        }

        shakeOffset = Vector3.zero;
    }

    private IEnumerator FadeTransition()
    {
        yield return StartCoroutine(FadeCanvas(0f, 1f, fadeDuration));
        yield return new WaitForSeconds(blackScreenDuration);
        yield return StartCoroutine(FadeCanvas(1f, 0f, fadeDuration));
    }

    private IEnumerator FadeCanvas(float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            fadeOverlay.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }
        fadeOverlay.alpha = to;
    }

    private void FollowPlayerCamera()
    {
        basePosition = Vector3.Slerp(basePosition, new Vector3(0, playerPos.position.y + 6, -12), cameraSmooth * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(23, 0, 0), cameraSmooth * Time.deltaTime);
        transform.position = basePosition + shakeOffset;
    }

    private void SideCameraView()
    {
        basePosition = Vector3.Slerp(basePosition, sideCamView.position, cameraSmooth * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, sideCamView.rotation, cameraSmooth * Time.deltaTime);
        transform.position = basePosition + shakeOffset;
    }

    void Start()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        if (GameStateChange)
        {
            SideCameraView();
        }
        else
        {
            FollowPlayerCamera();
        }
    }
}
