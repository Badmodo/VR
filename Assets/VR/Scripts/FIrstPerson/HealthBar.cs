using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float maxHealth = 100f;
    public static float health;
    public GameObject deathScreen;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //Destroy(gameObject);

        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
