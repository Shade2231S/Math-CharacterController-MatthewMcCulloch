using UnityEngine;

public class PlayerColision : MonoBehaviour
{
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
