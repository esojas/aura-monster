using System.Collections;
using UnityEngine;

public class AnastasiaAttack : EnemyAttack
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform projectileSpawnPos;
    [SerializeField] private float growDuration = 0.5f;
    [SerializeField] private float maxLength = 10f;
    [SerializeField] private float boltWidth = 0.5f;

    private int enemyAttackDamage;
    private float enemyAttackCooldown;
    private float enemyAttackSpeed;
    private GameObject enemyAttackPrefab;
    private bool attackIsCooldown = false;

    protected override void Attack()
    {
        if (!attackIsCooldown)
        {
            GameObject projectile = Instantiate(enemyAttackPrefab, projectileSpawnPos.position, projectileSpawnPos.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            AnastasiaDamageCollider damageColliderScript = projectile.GetComponent<AnastasiaDamageCollider>();
            damageColliderScript.damage = enemyAttackDamage;
            damageColliderScript.Initialize(growDuration, maxLength, boltWidth); 

            projectileRb.linearVelocity = projectile.transform.forward * enemyAttackSpeed;
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        attackIsCooldown = true;
        yield return new WaitForSeconds(enemyAttackCooldown);
        attackIsCooldown = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        if (enemyData == null) throw new System.NullReferenceException($"enemyData is not assign inside: {transform.name}");

        enemyAttackSpeed = enemyData.enemyAttackSpeed;
        enemyAttackCooldown = enemyData.enemyAttackCooldown;
        enemyAttackPrefab = enemyData.enemyAttackPrefab;
        enemyAttackDamage = enemyData.enemyAttackDamage;
    }
}
