using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openObjectives : MonoBehaviour
{
    public DoorOpenObjects door;
    public bool pressedForOpen = false;
    public string[] tags;

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in tags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                door.checks.Enqueue(gameObject.GetComponent<openObjectives>());
                Debug.Log("Enqueue");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
         foreach (string tag in tags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                door.checks.Dequeue();
                Debug.Log("Dequeued");
            }
        } 
    }



}
