using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject nextBoss;
    public GameObject nextBossHealthbar;
    public GameObject currentBossHealthbar;

    [SerializeField] private EnemyAdjustMaterial eam;
    //public ParticleSystem deathParticle;

    public void TakeDamage(float amount)
    {
        EnemyHealthBar.health -= amount;

        if (EnemyHealthBar.health <= 0f)
        {
            StartCoroutine(Die());
        }
        Debug.Log("bbamb");
    }

    IEnumerator Die()
    {
        currentBossHealthbar.SetActive(false);
        eam.Fader();
        //deathParticle.Play();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        nextBoss.SetActive(true);
        nextBossHealthbar.SetActive(true);
        //yield return new WaitForSeconds(1f);
    }
}
