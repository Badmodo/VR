using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ParticleSystem))]
public class Bullet : MonoBehaviour
{
    protected Rigidbody bulletRigidbody;
    protected ParticleSystem particle;

    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 angularVelocity;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.isKinematic = true;
        particle = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
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
        
    }
}
