using UnityEngine;

public class JuliusDamageCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider damageCollider;
    public int damage;

    private PlayerHealth playerHealth;
    private bool hasCollide = false;
    private Transform orbitCenter;
    private float orbitSpeed;
    private float radius;
    private float currentAngle;

    private void Awake()
    {
        damageCollider = GetComponent<BoxCollider>();
    }

    public void Initialize(Transform center, float speed)
    {
        orbitCenter = center;
        orbitSpeed = speed;

        radius = Vector3.Distance(transform.position, orbitCenter.position);

        Vector3 startOffset = transform.position - orbitCenter.position;
        currentAngle = Mathf.Atan2(startOffset.z, startOffset.x);
    }

    void Update()
    {
        if (orbitCenter == null) return;

        currentAngle += orbitSpeed * Time.deltaTime * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(currentAngle), 0f, Mathf.Sin(currentAngle)) * radius;
        transform.position = orbitCenter.position + offset;
    }


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


}
