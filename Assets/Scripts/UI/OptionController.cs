using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField] private GameObject optionScreen;
    [SerializeField] private Slider audioSlider;

    private void Awake()
    {
        audioSlider.value = AudioListener.volume;
        audioSlider.onValueChanged.AddListener(ChangeAudio);
    }

    public void CloseOptionButton()
    {
        optionScreen.SetActive(false);
    }

    private void ChangeAudio(float value)
    {
        AudioListener.volume = value;
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
