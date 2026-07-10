using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private int score;
    public int Score => score;
    [SerializeField] private TextMeshProUGUI scoreText;


    private void SetScore()
    {
        if (scoreText == null)
        {
            Debug.LogError("scoreText is not assigned!", this);
            return;
        }
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        SetScore();
    }

    void Start()
    {
        SetScore();
    }

    void Update()
    {

    }
}
