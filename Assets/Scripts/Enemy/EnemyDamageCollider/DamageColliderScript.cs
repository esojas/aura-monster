using UnityEngine;

public class DamageColliderScript : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;
    private bool hasCollide = false;

    private void OnTriggerEnter(Collider other)
    {
        // 3 is player layer
        if(other.gameObject.layer == 3 && !hasCollide)
        {
            hasCollide = true;
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            if (transform.name.Contains("MiasmaPrefab")) return;
            Invoke(nameof(Destroy), .01f);
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
        
    }
}
