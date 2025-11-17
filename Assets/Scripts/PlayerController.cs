using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3.5f;
    public Transform ori;
    public Camera camera;
    private Rigidbody rb;
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
}
