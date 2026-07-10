using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private AudioSource vfxAudioSource;
    [SerializeField] private AudioClip deathSound;

    public void StartButton()
    {
        ResetGlobalState();
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartButton()
    {
        ResetGlobalState();
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenuButton()
    {
        ResetGlobalState();
        SceneManager.LoadScene("MainMenu");
    }

    private void ResetGlobalState()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vfxAudioSource.clip = deathSound;
        vfxAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
