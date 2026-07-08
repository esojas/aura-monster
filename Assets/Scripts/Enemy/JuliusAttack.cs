using System.Collections;
using UnityEngine;

public class JuliusAttack : EnemyAttack
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform projectileSpawnPos;
    [SerializeField] private int swordSpawnMax = 3;
    private int enemyAttackDamage;
    private float enemyAttackCooldown;
    private float enemyAttackSpeed;
    private GameObject enemyAttackPrefab;
    private bool attackIsCooldown = false;
    private int swordSpawn;

    protected override void Attack()
    {
        if (!attackIsCooldown && swordSpawn < swordSpawnMax)
        {
            GameObject projectile = Instantiate(enemyAttackPrefab, projectileSpawnPos.position - enemyAttackPrefab.transform.position, Quaternion.identity);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            JuliusDamageCollider damageColliderScript = projectile.GetComponent<JuliusDamageCollider>();

            damageColliderScript.Initialize(transform, enemyAttackSpeed);
            damageColliderScript.damage = enemyAttackDamage;

            swordSpawn++;

            //projectileRb.linearVelocity = projectile.transform.forward * enemyAttackSpeed;
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
