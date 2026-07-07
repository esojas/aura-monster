using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int health;
    public int Health => health;

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            Invoke("Death", 0.1f);
        }
    }

    private void Death()
    {
        Debug.LogError("Dead");
    }

    private void SetMaxHealth()
    {
        healthBar.maxValue = health;
    }

    private void SetHealth()
    {
        healthBar.value = health;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
    }
}
