using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenObjects : MonoBehaviour
{

    public Queue<openObjectives> checks = new Queue<openObjectives>();
    public GameObject door;
    float doorHight = 5;

    bool openedDoor;
    public int openeds;

    void Update()      
    {
        Log();
        if (openeds == checks.Count)
        {
            openDoor();
        }
        
        if (checks.Count < openeds)
        {
            closeDoor();
        }
    }
    void closeDoor()
    {
        if (openedDoor == true)
        {
            door.transform.Translate(Vector3.up * -doorHight);
            openedDoor = false;
        }
    }
       
    void openDoor()
    {
        if (openedDoor == false)
        {
            door.transform.Translate(Vector3.up * doorHight);
            openedDoor = true;
        }
    }
    void Log()
    {
        Debug.Log(openedDoor);
        Debug.Log(openeds);
        Debug.Log(checks.Count);
    }
}
