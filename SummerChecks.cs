using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerChecks : MonoBehaviour
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
                    season.springActive = false;
                    season.autumnActive = false;
                    Debug.Log("Enact By Summer");
                }
            }
            Destroy(gameObject);
        }
    }
}
