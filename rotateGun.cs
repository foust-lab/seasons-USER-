using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{

    public shootingBullets shoot;

    private void Update()
    {
        transform.LookAt(shoot.shootingTOlook());
    }
}
