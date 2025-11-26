using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController con;
    public Rigidbody rb;
    public float walkspeed = 4.5f;
    public float runspeed = 8;
    public float jumpforce = 4f;
    public float lookspeed = 4f;
    public float lookxlimit = 85f;
    public float synsitivity = 1f;
    public float gravity = 10f;
    private float lookrotation;
    Vector2 move, look;
    public Camera camera;
    public bool isground;
    public bool canmove = true;
    public bool isrunning;
    public bool iswalking;
    public void onmove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void onlook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    public void Move()
    {

        Vector3 currentvel = rb.linearVelocity;
        Vector3 targetvel = new Vector3(move.x, 0, move.y);
        targetvel *= walkspeed;
        targetvel = transform.TransformDirection(targetvel);
        Vector3 velchange = (currentvel - targetvel);
        velchange = new Vector3(velchange.x, velchange.y, velchange.z);
        Vector3.ClampMagnitude(velchange, 4.5f);
        rb.AddForce(velchange, ForceMode.VelocityChange);
    }
    public void Look()
    {
        transform.Rotate(Vector3.up * look.x * synsitivity);
        lookrotation += (-look.y * synsitivity);
        lookrotation = Mathf.Clamp(lookrotation, -lookxlimit, lookxlimit);
        camera.transform.eulerAngles = new Vector3(lookrotation, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
    }
    void Start()
    {
        con = GetComponent<CharacterController>();
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;        
    }

    public void onjump(InputAction.CallbackContext context)
    {
        jump();
    }
    public void jump() 
    {
        //Vector3 jumpforces = Vector3.zero;
        //if (isground == true)
        //{
        //    jumpforces = Vector3.up * jumpforce;
        //}
        //rb.AddForce(jumpforces, ForceMode.VelocityChange);
    }
    void FixedUpdate()
    {
        
    }
    void Update()
    {
        Move();
        Look();
    }
    public void crouch()
    {

    }
    public void oncrouch(InputAction.CallbackContext context)
    {

    }
}