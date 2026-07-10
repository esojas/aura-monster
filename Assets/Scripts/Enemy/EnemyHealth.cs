using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private GameScore gameScore;
    private float enemyHealth;


    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            gameScore.IncreaseScore(enemyData.enemyScore);
            Invoke(nameof(Destroy), 0.1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameScoreObject = GameObject.FindWithTag("GameManager");
        gameScore = gameScoreObject.GetComponent<GameScore>();
        enemyHealth = enemyData.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
