using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Bullet : MonoBehaviour
{
    protected ParticleSystem particle;
    protected Vector3 playerPosition;


    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 angularVelocity;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        playerPosition = GameObject.FindWithTag("Player").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(playerPosition);
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Spin();
    }

    protected virtual void Move()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }

    protected virtual void Spin()
    {
        transform.Rotate(angularVelocity * Time.deltaTime, Space.World);
    }
}
