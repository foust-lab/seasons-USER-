using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnChecks : MonoBehaviour
{
    public float blastRadius;
    public GameObject decayEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 9)
        {
            Collider[] blasted = Physics.OverlapSphere(transform.position, blastRadius);
            foreach (Collider item in blasted)
            {
                seasonChangable season = item.gameObject.GetComponent<seasonChangable>();

                if (season != null)
                {
                    season.autumnActive = true;
                    season.springActive = false;
                    Debug.Log("Enact By Autumn");
                }
            }

            ParticleSystem hitE = Instantiate(decayEffect, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            hitE.Play();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
