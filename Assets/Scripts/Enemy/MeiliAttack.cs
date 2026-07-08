using System.Collections;
using UnityEngine;

public class MeiliAttack : EnemyAttack
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform projectileSpawnPos;
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

            DamageColliderScript damageColliderScript = projectile.GetComponent<DamageColliderScript>();

            damageColliderScript.damage = enemyAttackDamage;

            projectileRb.linearVelocity = projectile.transform.right * enemyAttackSpeed;
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        attackIsCooldown = true;
        float randomCooldown = Random.Range(3f, enemyAttackCooldown);
        yield return new WaitForSeconds(randomCooldown);
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
