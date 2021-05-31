using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Bullet : MonoBehaviour
{
    protected ParticleSystem particle;
    protected Transform player;


    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 angularVelocity;
    [SerializeField]
    protected float damage = 10.0f;
    [SerializeField]
    protected bool doesTargetPlayer = true;

    protected void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (doesTargetPlayer)
        {
            transform.LookAt(player.position);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        particle.Play();
    }

    private void OnEnable()
    {
        if (doesTargetPlayer)
        {
            transform.LookAt(player.position);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
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
        if (other.CompareTag("Player"))
            HealthBar.health -= damage;
    }
}
