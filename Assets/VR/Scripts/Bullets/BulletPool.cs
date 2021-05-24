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
    private static int waveMarker = 0;
    private List<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBullet()
    {

    }

    private GameObject SearchPool()
    {
        return default;
    }

    public static void NextPhase()
    {
        waveMarker++;
    }
}
