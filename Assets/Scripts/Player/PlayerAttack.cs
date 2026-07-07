using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float knifeSpeed;
    [SerializeField] private float knifeDamage;
    public float getKnifeDamage => knifeDamage;
    [SerializeField] private Transform knifeSpawnPos;
    [SerializeField] private float knifeCooldown = .01f;

    private PlayerControls playerControls;
    private bool attackIsCooldown = false;

    private void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
    }

    private void OnEnable()
    {
        playerControls.OnAttackPressed += SpawnKnife;
    }

    private void OnDisable()
    {
        playerControls.OnAttackPressed -= SpawnKnife;
    }

    private void SpawnKnife()
    {
        if (!attackIsCooldown)
        {
            GameObject knife = Instantiate(knifePrefab, knifeSpawnPos.position, knifeSpawnPos.rotation);
            Rigidbody knifeRb = knife.GetComponent<Rigidbody>();

            KnifeProjectile knifeProjectile = knife.GetComponent<KnifeProjectile>();

            knifeProjectile.SetDamage(knifeDamage);

            knifeRb.linearVelocity = knife.transform.forward * knifeSpeed;
            StartCoroutine(AttackCooldownCoroutine());
        }
        else
        {
            Debug.Log($"attack is in cooldown: {attackIsCooldown}");
        }
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        attackIsCooldown = true;
        yield return new WaitForSeconds(knifeCooldown);
        attackIsCooldown = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackIsCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
