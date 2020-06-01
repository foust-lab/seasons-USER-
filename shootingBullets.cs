using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingBullets : MonoBehaviour
{
    public float bulletSpeed = 15f;
    
    public Transform firePoint;
    public Camera cam;
    public LayerMask hitable;
    public float maxDistance;

    [Range(0,1)]
    public float FireRate;
    float fireTimer;
    Vector3 shootingPoint;

    [Header("Bullets")]
    public GameObject bullet1;
    public GameObject bullet2;

    [Header("GravityGun")]
    public float collectRadius;
    public float gravity;
    public LayerMask leaves;
    public ParticleSystem Geffect;

    private void Start()
    {
        Geffect.Stop();
    }

    private void Update()
    {
        UpdateFirePoint();
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && fireTimer >= FireRate)
        {
            shootBull(bullet1);
            fireTimer = 0f;
        }else if (Input.GetButton("Fire2") && fireTimer >= FireRate)
        {
            shootBull(bullet2);
            fireTimer = 0f;
        }
        if (Input.GetButtonDown("Fire5"))
        {
            Geffect.Play();
        }
        if (Input.GetButton("Fire5"))
        {
            GravityPull();
            
        }
        if (Input.GetButtonUp("Fire5"))
        {
            Geffect.Stop();
        }

    }

    public void UpdateFirePoint( )
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, hitable))
        {
            shootingPoint = hit.point;
        }
        else
        {
            shootingPoint = firePoint.forward * maxDistance;
        }
    }

    void shootBull(GameObject bullettype)
     {
        GameObject bullIns = Instantiate(bullettype, firePoint.position, firePoint.rotation);
        bullIns.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed);
     }

    public Vector3 shootingTOlook()
    {
        return shootingPoint;
    }

    void GravityPull()
    {
        
        Collider[] boxes = Physics.OverlapSphere(firePoint.position, collectRadius, leaves);
        foreach (Collider item in boxes)
        {
            Rigidbody Brig = item.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = firePoint.position - Brig.transform.position;
            if (Brig != null)
            {
                Brig.AddForce(-dir * gravity);
            }
        }
       
    }

}
