using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterChecks : MonoBehaviour
{
    public float blastRadius;

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
                    season.autumnActive = false;
                    season.springActive = false;
                    Debug.Log("Enact By Winter");
                }
            }
            Destroy(gameObject);
        }
    }
}
