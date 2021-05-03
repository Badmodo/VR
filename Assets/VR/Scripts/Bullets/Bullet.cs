using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    protected Rigidbody bulletRigidbody;

    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 angularVelocity;

    [SerializeField]
    protected bool isUsingPhysics = false;

    [SerializeField]
    protected float lifetime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        if (!isUsingPhysics)
            bulletRigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Spin();
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            OnLifetimeEnd();
    }

    protected virtual void Move()
    {
        if (isUsingPhysics)
        {
            bulletRigidbody.AddForce(velocity * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            transform.Translate(velocity * Time.deltaTime, Space.World);
        }
    }

    protected virtual void Spin()
    {
        if (isUsingPhysics)
        {
            bulletRigidbody.AddTorque(angularVelocity * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            transform.Rotate(angularVelocity * Time.deltaTime, Space.World);
        }
    }

    protected virtual void OnLifetimeEnd()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
