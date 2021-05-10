using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    Transform playerTransform;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.isKinematic = true;
        particle = GetComponent<ParticleSystem>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    protected override void Move()
    {
        transform.Translate(velocity * Time.deltaTime, Space.Self);
    }

    protected override void Spin()
    {
        Vector3 targetVector = transform.InverseTransformPoint(playerTransform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularVelocity.x * Time.deltaTime);
    }
}
