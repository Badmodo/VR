using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> bulletWaves;//This should have seven objects in it
    //On the first phase it will spawn the first three bullet prefabs
    //When the phase changes, the set of bullets will move up the list by one
    //Each pattern is harder than the previous ones
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
        Debug.Log(bulletPool.Count);
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

    private void SpawnBullet()
    {
        GameObject bullet = SearchPool();
        if (!bullet.activeInHierarchy)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
        }
    }

    private GameObject SearchPool()
    {
        return bulletPool[Random.Range(waveMarker, waveMarker + (bulletNum * 3))];
    }

    public void NextPhase()
    {
        waveMarker += bulletNum;
    }
}
