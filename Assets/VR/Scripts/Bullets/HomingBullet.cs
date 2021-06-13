using UnityEngine;

/// <summary>
/// This version of the Bullet script is always moving toward the player
/// </summary>
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

    /// <summary>
    /// Calculate the bullet's speed based on how far away it is, then move it that far in the direction it's facing
    /// </summary>
    protected override void Move()
    {
        float speed = (transform.position - player.position).magnitude;
        transform.Translate(velocity * Time.deltaTime * (speed/maxSpeed), Space.Self);
    }

    /// <summary>
    /// Rotate to face the player
    /// </summary>
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
