using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private float enemyHealth;


    public void TakeDamage(float damage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damage;
        }
        else
        {
            Invoke("Destroy", 0.1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = enemyData.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
