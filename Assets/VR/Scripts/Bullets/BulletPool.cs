using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the object pool for the boss' bullet patterns
/// </summary>
public class BulletPool : MonoBehaviour
{
    /// <summary>
    /// The list of different bullet patterns the boss has
    /// It should be equal to 2 + the number of phases the boss has
    /// </summary>
    [SerializeField]
    private List<GameObject> bulletWaves;
    /// <summary>
    /// Used to select what bullets to spawn based on the phase the boss is in
    /// This value isn't really used in the current version
    /// </summary>
    private int waveMarker = 0;
    /// <summary>
    /// How many bullets of each type in the pool
    /// </summary>
    private int bulletNum = 2;

    private List<GameObject> bulletPool;

    private float timer = 0.0f;
    [SerializeField]
    private float delay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();
        foreach(GameObject bullet in bulletWaves)
        {
            for(int i = 0; i < bulletNum; ++i)
            {
                GameObject newBullet = Instantiate(bullet);
                bulletPool.Add(newBullet);
                newBullet.SetActive(false);
            }
        }
        //Debug.Log(bulletPool.Count);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay)
        {
            timer = 0;
            SpawnBullet();
        }
    }

    /// <summary>
    /// Selects a random bullet from the pool, and spawns it in if it's inactive
    /// Otherwise, it does nothing
    /// </summary>
    private void SpawnBullet()
    {
        GameObject bullet = SearchPool();
        if (!bullet.activeInHierarchy)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
        }
    }

    /// <summary>
    /// Gets a random bullet from the pool based on what phase the boss is in
    /// </summary>
    private GameObject SearchPool()
    {
        return bulletPool[Random.Range(waveMarker, waveMarker + (bulletNum * 3))];
    }

    /// <summary>
    /// Moves the boss to the next phase
    /// </summary>
    public void NextPhase()
    {
        waveMarker += bulletNum;
    }
}
