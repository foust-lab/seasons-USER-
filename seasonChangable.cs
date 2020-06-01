using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasonChangable : MonoBehaviour
{
    public bool springActive;
    public bool autumnActive;

    public bool leavesFall;
    public int shedAmount = 4;
    public Transform[] spawnpooints;
    public GameObject leaves;

    public float growHeight = 1.4f;
    public int growthMax = 4;
    public int growthStart;
    public Vector3 growthDirect;
    public Gradient healthColor;
    public ParticleSystem decayEffect;
    public bool isDead;

    int growthStage;
    float randomNumber;
    int amount;
    MeshRenderer meshR;

    private void Start()
    {
        growthStage = growthStart + 3;
        growthMax += 3;
        meshR = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (springActive == true)
        {
            SpringGrow();
            springActive = false;
            isDead = false;
        }
        if(autumnActive == true)
        {        
            falldecay();
            autumnActive = false;
            if (leavesFall == true && growthStage == 0)
            {
                shedLeaves(spawnpooints,leaves);
            }
        }
        randomNumber = Random.Range(.01f, 1f);

    }
    void SpringGrow()
    {

        if (growHeight != 0 && growthStage < growthMax && growthStage >= 2)
        {
            transform.localScale += growthDirect * growHeight;
            growthStage++;
            
        }
        if (growthStage <= 2)
        {
            growthStage++;
        }
        if (growthStage >=1)
        {
            meshR.material.color = healthColor.Evaluate(0);
        }      
    }
    void falldecay()
    {
       
        if (growthStage != 0)
        {
            growthStage = growthStage - 1;
        }
        if (growHeight != 0 && growthStage >= 2  )
        {
            transform.localScale -= growthDirect * growHeight;
            decayEffect.Play();       
        }
        if (growthStage <=  1)
        {      
            meshR.material.color = healthColor.Evaluate(1);
        } 
       
    }

    void shedLeaves(Transform[] spawnPoints, GameObject leaves)
    {
       decayEffect.Play();
        amount++;
        if (amount >= shedAmount) return;
        foreach (Transform item in spawnPoints)
        {
           
            Instantiate(leaves, item.position, item.rotation);
        } foreach (Transform item in spawnPoints)
        {
           
            Instantiate(leaves, item.position, item.rotation);
        } foreach (Transform item in spawnPoints)
        {
           
            Instantiate(leaves, item.position + Vector3.down, item.rotation);
        }
        
    }

}
