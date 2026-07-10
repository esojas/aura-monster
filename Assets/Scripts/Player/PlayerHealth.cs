using System.Collections;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int health;
    [SerializeField] private MusicEvent musicEvent;
    [SerializeField] private float invincibilityDuration = 2f;
    [SerializeField] private SceneLoader sceneLoader;
    public int Health => health;
    private bool invincible = false;
    private Coroutine invincibilityRoutine;

    private void OnEnable()
    {
        musicEvent.GameStateChangeEvent += GameStateChange;
    }

    private void OnDisable()
    {
        musicEvent.GameStateChangeEvent -= GameStateChange;
    }

    private void GameStateChange(bool state)
    {
        if (invincibilityRoutine != null)
            StopCoroutine(invincibilityRoutine);

        invincibilityRoutine = StartCoroutine(InvincibilityWindow());
    }

    private IEnumerator InvincibilityWindow()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        invincible = false;
        invincibilityRoutine = null;
    }

    public void TakeDamage(int damage)
    {
        if (invincible) return;

        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(Death), 0.1f);
        }
    }

    private void Death()
    {
        sceneLoader.RestartButton(); 
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
