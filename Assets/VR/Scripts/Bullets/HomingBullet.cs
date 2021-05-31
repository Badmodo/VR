using UnityEngine;

public class HomingBullet : Bullet
{
    //Transform playerTransform;
    private float maxSpeed;

    protected override void Start()
    {
        base.Start();
        maxSpeed = (transform.position - player.position).magnitude;
        if(maxSpeed == 0)
        {
            maxSpeed += 0.01f;
        }
    }

    protected override void Move()
    {
        float speed = (transform.position - player.position).magnitude;
        transform.Translate(velocity * Time.deltaTime * (speed/maxSpeed), Space.Self);
    }

    protected override void Spin()
    {
        /*
        Vector3 targetVector = transform.InverseTransformPoint(playerTransform.position);
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularVelocity.x);
        */
        transform.LookAt(player.position);
    }
}
