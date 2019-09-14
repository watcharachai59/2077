using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerShoot : MonoBehaviour
{


    public float damage = 10f;
    public float range = 100f;

    public Camera fpscam;
    public ParticleSystem muzzleflashleft;
    public ParticleSystem muzzleflashright;
    public GameObject impactEffect;

    void Start()
    {
 
        
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        muzzleflashleft.Play();
        muzzleflashright.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);

            ScriptTargets targets = hit.transform.GetComponent<ScriptTargets>();
            if (targets != null)
            {
                targets.TakeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
