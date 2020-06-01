using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class playerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumphieght;

    public Transform groundCheck;
    public CharacterController controler;
    Vector3 velocity;
    public float groundDistince = .4f;
    public LayerMask whatsGround;
    bool isGrounded;
    Vector3 move;
    public Shaker Landing;
    public ShakePreset land;
    public ShakePreset running;
    bool wasGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistince, whatsGround);
        if(isGrounded == true && wasGrounded == false)
        {
            Landing.Shake(land);

        }

        wasGrounded = isGrounded;
        if (isGrounded  && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

         move = transform.right * x + transform.forward * y;

        controler.Move(move * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controler.Move(velocity * Time.deltaTime);

        if (isGrounded == true)
        {
            if (x > 0 || y > 0)
            {
                Landing.Shake(running);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controler.isGrounded && hit.normal.y < .1f && hit.gameObject.CompareTag("ClimbAble"))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                move = hit.normal * speed;
            }
        }
    }
}
