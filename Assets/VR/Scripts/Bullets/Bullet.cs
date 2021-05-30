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
    [SerializeField]
    protected float damage = 10.0f;
    [SerializeField]
    protected bool doesTargetPlayer = true;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        if(doesTargetPlayer)
            transform.LookAt(playerPosition);
        particle.Play();
    }

    private void OnEnable()
    {
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

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("");
        if (other.CompareTag("Player"))
            HealthBar.health -= damage;
    }
}
