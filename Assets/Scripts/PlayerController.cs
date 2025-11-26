using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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
    public void Start()
    {
        con = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
