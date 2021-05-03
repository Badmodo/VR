using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    protected Rigidbody bulletRigidbody;
    protected Collider bulletCollider;

    [SerializeField]
    protected Vector3 velocity;
    [SerializeField]
    protected Vector3 angularVelocity;

    [SerializeField]
    protected bool isUsingPhysics = false;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletCollider = GetComponent<Collider>();
        if (bulletCollider == null)
            bulletCollider = gameObject.AddComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Spin();
    }

    protected virtual void Move()
    {
        if (isUsingPhysics)
        {
            bulletRigidbody.AddForce(velocity * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    protected virtual void Spin()
    {
        if (isUsingPhysics)
        {
            bulletRigidbody.MoveRotation(Quaternion.Euler(angularVelocity * Time.deltaTime));
        }
        else
        {
            transform.Rotate(angularVelocity * Time.deltaTime);
        }
    }
}
