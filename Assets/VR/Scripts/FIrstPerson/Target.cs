using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject nextBoss;
    public GameObject nextBossHealthbar;
    public GameObject currentBossHealthbar;

    public void TakeDamage(float amount)
    {
        EnemyHealthBar.health -= amount;

        if (EnemyHealthBar.health <= 0f)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        currentBossHealthbar.SetActive(false);
        Destroy(gameObject);
        nextBoss.SetActive(true);
        nextBossHealthbar.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
