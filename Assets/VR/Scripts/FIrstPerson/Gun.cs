using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 200f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlashL;
    public ParticleSystem muzzleFlashR;
    public GameObject impactEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootLeft();
        }        
        if (Input.GetButtonDown("Fire2"))
        {
            ShootRight();
        }

    }

    void ShootLeft()
    {
        muzzleFlashL.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    void ShootRight()
    {
        muzzleFlashR.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
