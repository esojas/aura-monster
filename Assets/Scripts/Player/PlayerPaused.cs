using UnityEngine;

public class PlayerPaused : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private PlayerControls playerControls;
    private bool togglePause = false;

    private void OnEnable()
    {
        playerControls.OnPausePressed += TogglePause;
    }

    private void OnDisable()
    {
        playerControls.OnPausePressed -= TogglePause;
    }

    private void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
    }

    private void TogglePause()
    {
        togglePause = !togglePause;
        pauseScreen.SetActive(togglePause);
        Time.timeScale = togglePause ? 0f : 1f;
        AudioListener.pause = togglePause;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
