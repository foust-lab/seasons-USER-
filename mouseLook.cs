using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSentictive = 100f, mouseZoom = 30f;
    public Transform playerBody;

    float xRotation = 0f;

    float mouseX;
    float mouseY;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (true)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSentictive * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSentictive * Time.deltaTime;
        }
       

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        
    }
}
