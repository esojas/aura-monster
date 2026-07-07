using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public float enemyHealth;
    public int enemyAttackDamage;
    public float enemyAttackCooldown;
    public float enemyAttackSpeed;
    public GameObject enemyAttackPrefab;
    public float spawnProbability;
}
