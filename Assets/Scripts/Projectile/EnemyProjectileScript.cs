using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField] private float projectileLifetime = 6f;
    private EnemyHealth enemyHealth;


    private void ProjectileLifetime()
    {
        if (projectileLifetime > 0) projectileLifetime -= Time.deltaTime;
        if (projectileLifetime <= 0)
        {
            Invoke(nameof(Destroy), .1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProjectileLifetime();
    }
}
