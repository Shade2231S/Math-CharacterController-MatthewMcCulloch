using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private CharacterController con;
    public float walkspeed = 4.5f;
    public float jumpforce = 4f;
    public float lookspeed = 4f;
    public float lookxlimit = 85f;
    public float gravity = 10f;
    private float lookrotation;
    Vector3 velocity;
    public Transform groundcheck;
    public Camera camera;
    public bool isground;
    public void Start()
    {
        con = GetComponent<CharacterController>();
        
    }
    public void Update()
    {
        bool groundplayer = con.isGrounded;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        con.Move(move * walkspeed * Time.deltaTime);
        move *= walkspeed;
        velocity.y -= gravity * Time.deltaTime;
        con.Move(velocity * Time.deltaTime);
        if (isground && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && groundplayer)
        {
                velocity.y = jumpforce;
        }
        move.y = velocity.y;
        con.Move(move * Time.deltaTime);
        float mouseX = Input.GetAxis("Mouse X") * lookspeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookspeed;        
        lookrotation -= mouseY;
        lookrotation = Mathf.Clamp(lookrotation, -lookxlimit, lookxlimit);
        camera.transform.localRotation = Quaternion.Euler(lookrotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}