using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button showOptionButton;
    [SerializeField] private Button hideOptionButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject optionUI;

    private bool optionIsVisible =false;

    private void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void LoadOption()
    {
        optionIsVisible = true;
        if (optionIsVisible)
        {
            optionUI.gameObject.SetActive(true);
        }
    }

    private void CloseOption()
    {
        optionIsVisible = false;
        if (!optionIsVisible)
        {
            optionUI.gameObject.SetActive(false);
        }
    }

    private void ExitGame()
    {
    #if UNITY_EDITOR
            // Stops Play Mode in the Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            // Closes the built application
            Application.Quit();
    #endif
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        showOptionButton.onClick.AddListener(LoadOption);
        hideOptionButton.onClick.AddListener(CloseOption);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
