using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringChecks : MonoBehaviour
{
    public float blastRadius;
    public GameObject hitEffect;
    
    private void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.layer != 9) {

           Collider[] blasted = Physics.OverlapSphere(transform.position, blastRadius);
            foreach (Collider item in blasted)
            {
                seasonChangable season = item.gameObject.GetComponent<seasonChangable>();

                if (season != null )
                {
                    season.springActive = true;
                    season.autumnActive = false;
                    Debug.Log("Enact By Spring");
                }
            }

             ParticleSystem hitE = Instantiate(hitEffect, transform.position,transform.rotation).GetComponent<ParticleSystem>();
             hitE.Play();
             Destroy(gameObject);          
        }
        Destroy(gameObject);   
    }
}
