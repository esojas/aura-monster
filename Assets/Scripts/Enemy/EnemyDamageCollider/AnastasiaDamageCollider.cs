using UnityEngine;

public class AnastasiaDamageCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider damageCollider;
    public int damage;

    private float growDuration;
    private float maxLength;
    private float boltWidth;
    private float timer = 0f;

    private PlayerHealth playerHealth;
    private bool hasCollide = false;

    private void OnTriggerEnter(Collider other)
    {
        // 3 is player layer
        if (other.gameObject.layer == 3 && !hasCollide)
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

    public void Initialize(float growDuration, float maxLength, float boltWidth)
    {
        this.growDuration = growDuration;
        this.maxLength = maxLength;
        this.boltWidth = boltWidth;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / growDuration);
        float currentLength = Mathf.Lerp(0f, maxLength, t);

        damageCollider.size = new Vector3(boltWidth, boltWidth, currentLength);
        damageCollider.center = new Vector3(0f, 0f, currentLength / 2f);
    }
}
