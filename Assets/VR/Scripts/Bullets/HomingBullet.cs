using UnityEngine;

public class HomingBullet : Bullet
{
    //Transform playerTransform;
    private float maxSpeed;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    protected override void Start()
    {
        base.Start();
        maxSpeed = (transform.position - playerPosition).magnitude;
    }

    protected override void Move()
    {
        float speed = (transform.position - playerPosition).magnitude;
        transform.Translate(velocity * Time.deltaTime * (speed/maxSpeed), Space.Self);
    }

    protected override void Spin()
    {
        /*
        Vector3 targetVector = transform.InverseTransformPoint(playerTransform.position);
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularVelocity.x);
        */
        transform.LookAt(playerPosition);
    }
}
