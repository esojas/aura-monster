using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject playerPos;
    [SerializeField] private float attackRange = 2f;


    public void TryAttack(Transform target)
    {
        if (target == null) 
        {
            Debug.LogWarning($"Target doesnt exist");
            return;
        }

        // Calculate distance to the target
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            return;
        }
    }

    protected abstract void Attack();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerPos = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TryAttack(playerPos.transform);
    }
}
