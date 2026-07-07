using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    [SerializeField] private float knifeLifetime = 6f;
    private float damage;
    private bool hasCollide = false;
    private EnemyHealth enemyHealth;

    public void SetDamage(float damageInput)
    {
        damage = damageInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 7 is enemies layer
        if (other.gameObject.layer == 7 && !hasCollide)
        {
            hasCollide = true;
            enemyHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                //Debug.Log($"<color=green>[HIT SUCCESS]</color> Dealing {damage} damage to {other.gameObject.name}!");
                enemyHealth.TakeDamage(damage);
                Invoke(nameof(Destroy), .01f);
            }
            else
            {
                //Debug.LogError($"<color=red>[HIT ERROR]</color> Collided with '{other.gameObject.name}' on layer 6, but it is missing the EnemyHealth component!");
            }
        }
    }

    private void KnifeLifetime()
    {
        if(knifeLifetime > 0) knifeLifetime -= Time.deltaTime;
        if (knifeLifetime <= 0)
        {
            Invoke(nameof(Destroy),.1f);
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
        KnifeLifetime();
    }
}
